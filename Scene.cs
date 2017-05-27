using System.Collections.Generic;

namespace template
{
    class Scene
    {
        private List<Light> lights;
        private List<Primitive> _primitives;

        public List<Primitive> Primitives
        {
            get { return _primitives; }
        }

        public Scene(List<Light> lights, List<Primitive> primitives)
        {
            this.lights = lights;
            _primitives = primitives;
        }

        protected void AddLight(Light l)
        {
            lights.Add(l);
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
                if(intersection != null && intersection.Ray.magnitude < minD)
                {
                    minD = intersection.Ray.magnitude;
                    closest = intersection;
                }
                intersection = null;
            }
            return closest;
        }
    }
}
