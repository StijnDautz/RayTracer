using OpenTK;
using System.Collections.Generic;

namespace template
{
    class Scene
    {
        private List<Light> _lights;
        private List<Primitive> _primitives;

        public List<Primitive> Primitives
        {
            get { return _primitives; }
        }

        public List<Light> Lights
        {
            get { return _lights; }
        }

        public Scene()
        {
            _lights = new List<Light>();
            _primitives = new List<Primitive>();
        }

        public void AddLight(Light l)
        {
            _lights.Add(l);
        }

        public void AddPrimitive(Primitive p)
        {
            _primitives.Add(p);
        }

        public Intersection GetClosestIntersection(VectorMath.Ray ray)
        {
            float minD = float.MaxValue;
            Intersection intersection = null;
            Intersection closest = null;
            foreach (Primitive p in _primitives)
            {
                intersection = p.GetIntersection(ray);
                if(intersection != null && intersection.Distance < minD)
                {
                    minD = intersection.Distance;
                    closest = intersection;
                }
            }
            return closest;
        }

        public bool IsInShadow(Intersection intersection, Light light)
        {
            Vector3 dir = Vector3.Normalize(light.Position - intersection.IntersectionPoint);
            //if the dot product is smaller then one, then the light source is behind the primitive itself and so we immediately return true,
            //to prevent looping through all primitives in the scene
            if (Vector3.Dot(dir, intersection.Normal) < 0)
            {
               return true;
            }

            //if there is no intersection or the intersecting primitive is behind the light source, increase the lightAttenuation
            Intersection i = GetClosestIntersection(new VectorMath.Ray(intersection.IntersectionPoint + dir * 0.001f, dir));
            if (i != null && dir.Length > i.Distance)
            {
                return true;
            }
            //if no object was between the light and the intersection, then the intersection point isn't in a shadow and so we return false
            return false;
        }

        public Vector3 GetIntersectionColor(Intersection intersection)
        {
            Vector3 color = Vector3.Zero;
            foreach (Light l in _lights)
            {
                if (!IsInShadow(intersection, l))
                { color += intersection.primitive.ComputeColor(l.DirectIllumination(intersection.IntersectionPoint, intersection.Normal)); }
            }
            return color;
        }
    }
}