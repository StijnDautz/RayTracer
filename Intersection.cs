using OpenTK;

namespace template
{
    class Intersection
    {
        private Primitive _primitive;
        private Vector3 _normal;
        private VectorMath.Ray _ray;

        public Primitive primitive
        {
            get { return _primitive; }
        }

        public Vector3 Normal
        {
            get { return _normal; }
        }

        public Vector3 Position
        {
            get { return _ray.origin + _ray.magnitude * _ray.direction; }
        }

        public float Distance
        {
            get { return _ray.magnitude; }
        }


        public Intersection(Primitive primitive, Vector3 normal, VectorMath.Ray ray)
        {
            _primitive = primitive;
            _normal = normal;
            _ray = ray;
        }
    }
}
