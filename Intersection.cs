using OpenTK;

namespace template
{
    public class Intersection
    {
        private Primitive _primitive;
        private Vector3 _normal;
        private VectorMath.Ray _ray;
        private float _distance;

        public float Distance
        {
            get
            {
                return _distance;
            }
        }

        public Primitive primitive
        {
            get { return _primitive; }
        }

        public Vector3 Normal
        {
            get { return _normal; }
        }

        public VectorMath.Ray Ray
        {
            get { return _ray; }
        }

        public Intersection(Primitive primitive, Vector3 normal, VectorMath.Ray ray, float distance)
        {
            _primitive = primitive;
            _normal = normal;
            _ray = ray;
            _distance = distance;
        }
    }
}
