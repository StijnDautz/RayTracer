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

        protected virtual float GetAttenuation(Intersection intersection, Scene scene)
        {
            float attenuation = 0;
            if(!InShadow(intersection, Position, scene))
            {
                attenuation = GetAttenuation(intersection, Position, scene);
            }
            return attenuation;
        }

        protected float GetAttenuation(Intersection intersection, Vector3 position, Scene scene)
        {
            float dist = (position - intersection.IntersectionPoint).Length;
            return 1 - (1 / (dist * dist * 2));
        }

        public Vector3 ComputeIllumination(Intersection intersection, Scene scene)
        {
            float attenuation = GetAttenuation(intersection, scene);
            float dot = Vector3.Dot(intersection.Normal, (Position - intersection.IntersectionPoint).Normalized());
            Vector3 c = _color * attenuation * Intensity * dot;
            return c;
        }

        public bool InShadow(Intersection intersection, Vector3 position, Scene scene)
        {
            Vector3 dir = position - intersection.IntersectionPoint;
            //if the dot product is smaller then one, then the light source is behind the primitive itself and so we immediately return true,
            //to prevent looping through all primitives in the scene
            float dot = Vector3.Dot(dir.Normalized(), intersection.Normal);
            if (dot < 0)
            {
                return true;
            }

            //if there is no intersection or the intersecting primitive is behind the light source, increase the lightAttenuation
            Intersection i = scene.GetClosestIntersection(new VectorMath.Ray(intersection.IntersectionPoint + 0.001f * dir.Normalized(), dir));
            if (i != null && dir.Length > i.Distance)
            {
                return true;
            }
            //if no object was between the light and the intersection, then the intersection point isn't in a shadow and so we return false
            return false;
        }
    }
}
