using OpenTK;
using System;

namespace template
{
    class Sphere : Primitive
    {
        private float _radius;

        public Sphere(Vector3 position, int radius, Vector3 color, Material material) : base(position, color, material)
        {
            _radius = radius;
        }

        public float Radius
        {
            get { return _radius; }
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {          
            Vector3 centerToOrigin = ray.origin - Position;
            float b = 2 * Vector3.Dot(ray.direction, centerToOrigin);

            //a is always one (dotproduct with itself)
            float d = b * b - 4 * (centerToOrigin.Length * centerToOrigin.Length - _radius * _radius);
            if (d < 0)
            { return null; }
            else
            {
                d = (float)Math.Sqrt(d);
                float t0 = -b - d;
                float t1 = -b + d;
                t0 = t0 < t1 ? t0 : t1;

                Vector3 intersectionPoint = ray.origin + ray.direction * 0.5f * t0;
                return new Intersection(this, intersectionPoint, Vector3.Normalize(intersectionPoint - Position), ray, (intersectionPoint - ray.origin).Length);
            }     
        }
    }
}