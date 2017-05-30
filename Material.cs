using OpenTK;
using System;

namespace template
{
    public class Material
    {
        private Vector3 _color;
        private bool _isReflective;
        private bool _textured;
        private float _refractionIndex; //Has to do with bending of light in glass
        private float _reflectionIndex; //% of light being reflected (0f -> 1f)

        public float RefractionIndex
        {
            get { return _refractionIndex; }
        }

        public float ReflectionIndex
        {
            get { return _reflectionIndex; }
            set { _reflectionIndex = Math.Min(1f, value); }
        }

        public Vector3 Color
        {
            get { return _color; }
        }

        public bool IsReflective
        {
            get { return _isReflective; }
        }


        public Material(Vector3 color, bool isReflective, bool isGlass, float reflectionIndex = 0, float refractionIndex = 0)
        {
            _color = color;
            _isReflective = isReflective;
            _reflectionIndex = reflectionIndex;
            _isGlass = isGlass;
            _refractionIndex = refractionIndex;
        }
    }
}
