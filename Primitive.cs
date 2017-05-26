using OpenTK;

namespace template
{
    abstract class Primitive
    {
        private Vector3 _position;

        public Vector3 Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public Primitive(Vector3 position)
        {
            _position = position;
        }

        public virtual Intersection GetIntersection(Raytracer.Ray ray)
        {
            return null;
        }

        public float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }
    }
}
