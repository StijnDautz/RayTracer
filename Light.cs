using OpenTK;

namespace template
{
    public class Light : Object
    {
        private Vector3 _color;
        private Vector3 _intensity;

        public Vector3 Color
        {
            get { return _color; }
        }

        public Vector3 Intensity
        {
            get { return _intensity; }
        }
        public Light(Vector3 position, Vector3 color, Vector3 intensity) : base(position)
        {
            _color = color;
            _intensity = intensity;
        }

        public Vector3 DirectIllumination(Vector3 intersectionPoint, Vector3 normal)
        {
            Vector3 L = Position - intersectionPoint;
            float dist = L.Length;
            L *= (1.0f / dist);
            float attenuation = 1 / (dist * dist);
            return _color * Vector3.Dot(normal, L) * attenuation * Intensity;
        }
    }
}
