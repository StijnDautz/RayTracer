using OpenTK;
using System;
using System.Drawing;

namespace template
{
    class Sphere : Primitive
    {
        private float _radius;

        public Sphere(Vector3 position, float radius, float color = 000000000f) : base(position, color)
        {
            _radius = radius;
        }

        public float Radius
        {
            get
            {
                return _radius;
            }
        }
        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            Vector3 centerToOrigin = ray.origin - Position;
            float a = VectorMath.Dot(ray.direction, ray.direction);
            float b = VectorMath.Dot(2 * ray.direction, centerToOrigin);
            float c = VectorMath.Dot(centerToOrigin, centerToOrigin) - _radius * _radius;

            float d = (float)Math.Sqrt(b * b - 4 * a * c);
            Vector3 intersectionPoint = ray.origin + ray.direction * (float)((-b - Math.Sqrt(d)) / (2 * a));
            Vector3 normal = Vector3.Normalize(intersectionPoint - Position);
            if(d < 0)
            { return null; }
            else
            {
                return new Intersection(this, normal, ray);
            }
            

            /*//Geometry solution:
            Vector3 L = Position - ray.origin;
            Vector3 D = ray.direction;
            float tca = VectorMath.Dot(L, D);

            if (tca < 0) return null;

            float d = (float)Math.Sqrt(tca * tca + L.Length * L.Length); //d = minimum distance (perpendicular) between Sphere's center and the ray

            if (d < 0 || d > _radius) return null;

            float thc = (float)Math.Sqrt(_radius * _radius + d * d);
            Vector3 intersectionPoint = ray.origin + (tca - thc) * ray.direction;
            Vector3 normal = Vector3.Normalize(intersectionPoint - Position);
            return new Intersection(this, normal, ray);*/
        }
    }
}
