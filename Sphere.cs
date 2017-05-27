using OpenTK;
using System;
using System.Drawing;

namespace template
{
    class Sphere : Primitive
    {
        private int _radius;

        public Sphere(Vector3 position, int radius, Vector3 color) : base(position, color)
        {
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            Vector3 centerToOrigin = ray.origin - Position;
            float a = VectorMath.Dot(ray.direction, ray.direction);
            float b = VectorMath.Dot(2 * ray.direction, centerToOrigin);
            float c = VectorMath.Dot(centerToOrigin, centerToOrigin) - _radius * _radius;

            float d = (float)b * b - 4 * a * c;
            if (d < 0)
            { return null; }
            else
            {
                Vector3 intersectionPoint = ray.origin + ray.direction * (float)((-b - Math.Sqrt(d)) / (2 * a));
                Vector3 normal = Vector3.Normalize(intersectionPoint - Position);
                return new Intersection(this, normal, ray, (intersectionPoint - ray.origin).Length);
            }
        }
    }
}
