using OpenTK;

namespace template
{
    abstract class Primitive
    {
        private Vector3 _position;
        private bool _isMirror;
        private float _color;

        public Vector3 Position
        {
            set { _position = value; }
            get { return _position; }
        }

        //TODO add materials and move this property to the material
        public bool IsMirror
        {
            get { return _isMirror; }
            set { _isMirror = value; }
        }

        public Primitive(Vector3 position, float color = 000000000f)
        {
            _position = position;
            _color = color;
        }

        public virtual Intersection GetIntersection(VectorMath.Ray ray)
        {
            return null;
        }
    }
}
