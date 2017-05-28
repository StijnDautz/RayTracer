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


        public Scene(List<Light> lights, List<Primitive> primitives)
        {
            _lights = lights;
            _primitives = primitives;
        }

        protected void AddLight(Light l)
        {
            _lights.Add(l);
        }

        protected void AddPrimitive(Primitive p)
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
                intersection = null;
            }
            return closest;
        }

        public bool IsInShadow(Vector3 intersectionPoint, Vector3 normal, Light light)
        {
            Vector3 dir = light.Position - intersectionPoint;
            //if the dot product is smaller then one, then the light source is behind the primitive itself and so we immediately return true,
            //to prevent looping through all primitives in the scene
            if (VectorMath.Dot(dir, normal) < 0)
            {
                return true;
            }
            foreach (Primitive p in _primitives)
            {
                //if there is no intersection or the intersecting primitive is behind the light source, increase the lightAttenuation
                if (intersectionPoint != null && dir.Length > GetClosestIntersection(new VectorMath.Ray(intersectionPoint + dir * 0.005f, dir)).Distance)
                {
                    return true;
                }
            }
            //if no object was between the light and the intersection, then the intersection point isn't in a shadow and so we return false
            return false;
        }
    }
}
