using OpenTK;

namespace template
{
    public abstract class Primitive
    {
        private Vector3 _position;
        private bool _isMirror;
        private Vector3 _color;

        public Vector3 Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public Vector3 Color
        {
            get
            {
                return _color;
            }
        }

        //TODO add materials and move this property to the material
        public bool IsMirror
        {
            get { return _isMirror; }
            set { _isMirror = value; }
        }

        public Primitive(Vector3 position, Vector3 color)
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
