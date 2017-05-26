using OpenTK;
using System.Collections.Generic;

namespace template
{
    class Scene
    {
        List<Light> lights;
        List<Primitive> primitives;

        protected void AddLight(Light l)
        {
            lights.Add(l);
        }
        protected void AddPrimitive(Primitive p)
        {
            primitives.Add(p);
        }

        public Intersection GetClosestIntersection(VectorMath.Ray ray)
        {
            float minD = float.MaxValue;
            Intersection intersection = null;
            Intersection closest = null;
            foreach (Primitive p in primitives)
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
    }
}
