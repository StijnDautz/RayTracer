using OpenTK;

namespace template
{
    public class Light : Object
    {
        private Vector3 _intensity;

        public Light(Vector3 position, Vector3 color, Vector3 intensity) : base(position, color)
        {
            _intensity = intensity;
        }

        public Vector3 Intensity
        {
            get { return _intensity; }
        }
    }
}
