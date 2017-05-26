using OpenTK;

namespace template
{
    class Intersection
    {
        private float _distance;
        private Primitive _primitive;
        private Vector3 _normal;

        public Intersection(Primitive primitive, Vector3 normal, float distance)
        {
            _primitive = primitive;
            _normal = normal;
            _distance = distance;
        }
    }
}
