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

        public Intersection GetClosestIntersection(Raytracer.Ray ray)
        {
            float minD = float.MaxValue;
            Intersection intersection = null;
            Intersection closest;
            foreach (Primitive p in primitives)
            {
                Intersection i = p.GetIntersection(ray);
                if(i != null && intersection.distance < minD)
                {
                    minD = intersection.distance;
                    closest = intersection;
                }
            }
            return closest;
        }
    }
}
