using OpenTK;
using System;

namespace template
{
    class Sphere : Primitive
    {
        private float _radius;

        public Sphere(Vector3 position, float radius) : base(position)
        {
            _radius = radius;
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            Vector3 centerToOrigin = ray.origin - Position;
            float a = VectorMath.Dot(ray.direction, ray.direction);
            float b = VectorMath.Dot(2 * ray.direction, centerToOrigin);
            float c = VectorMath.Dot(centerToOrigin, centerToOrigin) - _radius * _radius;

            float d = -b + (float)Math.Sqrt(b * b - 4 * a * c) / 2 * a;
            if(d < 0)
            { return null; }
            else
            {
                
            }
            return null;
        }
    }
}
