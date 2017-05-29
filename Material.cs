using OpenTK;

namespace template
{
    public class Material
    {
        private Vector3 _color;
        private bool _isReflective;
        private int[] _texture;

        public Vector3 Color
        {
            get { return _color; }
        }

        public bool IsReflective
        {
            get { return _isReflective; }
        }


        public Material(Vector3 color, bool isReflective)
        {
            _color = color;
            _isReflective = isReflective;
        }
    }
}
