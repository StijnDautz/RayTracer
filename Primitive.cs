using OpenTK;

namespace template
{
    public abstract class Primitive : Object
    {
        Material _material;
        private float _refractionIndex;

        public Material Material
        {
            get { return _material; }
        }

        public bool IsReflective
        {
            get { return _material.IsReflective; }
        }

        public float RefractionIndex
        {
            get { return _refractionIndex; }
            set { _refractionIndex = value; }
        }



        public Primitive(Vector3 position, Vector3 color, Material material) : base(position)
        {
            _material = material;
        }

        public virtual Intersection GetIntersection(VectorMath.Ray ray)
        {
            return null;
        }

        public Vector3 ComputeColor(Vector3 alpha)
        {
            return Material.Color * alpha;
        }
    }
}
