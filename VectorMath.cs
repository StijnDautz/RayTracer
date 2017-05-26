using OpenTK;

namespace template
{
    static class VectorMath
    {
        public struct Ray
        {
            public Vector3 origin;
            public Vector3 direction;
            public float magnitude;

            public Ray(Vector3 o, Vector3 d, float m)
            {
                origin = o;
                direction = d;
                magnitude = m;
            }

            public Vector3 Position
            {
                get { return origin + magnitude * direction; }
            }
        }

        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            return incoming + normal * (2 * Dot(incoming, normal));
        }
    }
}
