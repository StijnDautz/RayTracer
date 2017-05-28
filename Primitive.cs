using OpenTK;

namespace template
{
    public abstract class Primitive : Object
    {
        private bool _isMirror;
        private bool _isGlass;
        private float _refractionIndex;

        //TODO add materials and move this property to the material
        public bool IsMirror
        {
            get { return _isMirror; }
            set { _isMirror = value; }
        }

        public bool IsGlass
        {
            get { return _isGlass; }
            set { _isGlass = value; }
        }

        public float RefractionIndex
        {
            get { return _refractionIndex; }
            set { _refractionIndex = value; }
        }

        public Primitive(Vector3 position, Vector3 color) : base(position, color)
        {

        }

        public virtual Intersection GetIntersection(VectorMath.Ray ray)
        {
            return null;
        }
    }
}
