using OpenTK;

namespace template
{
    public abstract class Object
    {
        private Vector3 _position;
        private Vector3 _color;

        public Vector3 Position
        {
            get { return _position; }
        }

        public Vector3 Color
        {
            get { return _color; }
        }

        public Object(Vector3 position, Vector3 color)
        {
            _position = position;
            _color = color;
        }
    }
}
