using OpenTK;

namespace template
{
    class Plane : Primitive
    {
        private Vector3 _normal;
        
        public Plane(Vector3 position, Vector3 normal) : base(position)
        {
            _normal = normal;
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            //if the ray is not parralel to the plane, calculate the intersection point
            if(VectorMath.Dot(_normal, ray.direction) != 0)
            {
                Vector3 p = ray.origin + (-(VectorMath.Dot(ray.origin, _normal) + Position.Length) / VectorMath.Dot(ray.direction, _normal)) * ray.direction;
                return new Intersection(this, _normal, ray);
            }
            else { return null; }
        }
    }
}
