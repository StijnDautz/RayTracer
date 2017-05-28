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

        public float CastShadowRays(Vector3 intersection)
        {
            Vector3 dir;
            float lightAttenuation = 0;
            foreach(Light l in _lights)
            {
                foreach(Primitive p in _primitives)
                {
                    dir = l.Position - intersection;
                    //if there is no intersection or the intersecting primitive is behind the light source, increase the lightAttenuation
                    if(intersection == null || dir.Length < GetClosestIntersection(new VectorMath.Ray(intersection, dir)).Distance)
                    {
                        lightAttenuation += 1 / (dir.Length * dir.Length);
                    }
                }
            }
            return lightAttenuation;
        }
    }
}
