using OpenTK;

namespace template
{
    class Camera
    {
        private Vector3 _position;
        private Vector3 _direction;
        private Screen _screen;
        public Vector3 _offset;
        public Vector3 Position
        {
            get { return _position + _offset; }
            set
            {
                _position = value;
                //TODO change _screen corners
            }
        }

        public Vector3 Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                //TODO change _screen corners
            }
        }

        public Vector3 Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        public Screen Screen
        {
            get { return _screen; }
        }

        public Camera(Vector3 position, Vector3 direction, Screen screen, Vector3 offset)
        {
            _position = position;
            _direction = direction;
            _screen = screen;
            _offset = offset;
            screen.ScreenDistance = (_position - screen.Position);
        }
    }
}
