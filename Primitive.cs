using OpenTK;

namespace template
{
    public abstract class Primitive : Object
    {
        private bool _isMirror;

        //TODO add materials and move this property to the material
        public bool IsMirror
        {
            get { return _isMirror; }
            set { _isMirror = value; }
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
