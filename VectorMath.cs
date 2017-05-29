using OpenTK;
using System;

namespace template
{
    public static class VectorMath
    {
        public struct Ray
        {
            public Vector3 origin;
            public Vector3 direction;
            public float magnitude;
            public bool inSphere;

            public Ray(Vector3 o, Vector3 d, bool inSphere = false)
            {
                origin = o;
                magnitude = d.Length;
                direction = d.Normalized();
                this.inSphere = inSphere;
            }

            public Vector3 Position
            {
                get { return origin + magnitude * direction; }
            }
        }

        public static Vector3 Reflect(Vector3 incoming, Vector3 normal)
        {
            return incoming - normal * (2 * Vector3.Dot(incoming, normal));
        }

        public static Vector3 Refract(Ray incoming, Vector3 normal, float refractionIndex)
        {
            float n;
            float angle = Vector3.Dot(-normal, incoming.direction); //Cos(angle)
            if (incoming.inSphere) n = refractionIndex; //refractionIndex medium 1 / medium 2
            else n = 1 / refractionIndex;
            return Vector3.Normalize(n * incoming.direction + (n*angle - (float)Math.Sqrt(1 - n*n*(1-(angle)*(angle)))) * normal);
        }


        public static int GetColorInt(Vector3 color)
        {
            color = Vector3.Clamp(color, Vector3.Zero, new Vector3(1,1,1));
            color *= 255;
            return ((int)color.Z << 0) | ((int)color.Y << 8) | ((int)color.X << 16);
        }
    }
}