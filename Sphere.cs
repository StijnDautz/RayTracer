using OpenTK;
using System;

namespace template
{
    class Sphere : Primitive
    {
        private int _radius;

        public Sphere(Vector3 position, int radius) : base(position)
        {
            _radius = radius;
        }

        public int Radius
        {
            get { return _radius; }
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            /*Vector3 centerToOrigin = ray.origin - Position;
            float a = VectorMath.Dot(ray.direction, ray.direction);
            float b = VectorMath.Dot(2 * ray.direction, centerToOrigin);
            float c = VectorMath.Dot(centerToOrigin, centerToOrigin) - _radius * _radius;

            float d = -b + (float)Math.Sqrt(b * b - 4 * a * c) / 2 * a;
            if(d < 0)
            { return null; }
            else
            {
                
            }
            return null;*/

            /*
             * Probleem Dot product van L en D wanneer deze niet genormalized zijn is heel groot en berekent niet de echte verhouding. 
             * De lengte van de ray doet er immers niet toe, alleen de richting. L en D moeten dus genormalized worden.
             * Vervolgens kan d berekent worden, maar daarna is er een probleem. De radius heeft niet de juiste verhouding met de genormaliseerde vectoren.
             * Thc kan dus niet berekent worden... 
             * Oplossing is verhouding berekenen om weer te herstellen naar originele lengte?
             * 
             * Op dit moment worden de rays alleen getekent wanneer ze intersecten met de sphere. Bij de genormaliseerde versie worden ze allemaal getekent.
             * Bij die van jou kreeg ik geen rays op het scherm. We hebben hetzelfde algoritme gebruikt.
             */

            Vector3 L = (Position - ray.origin);
            Vector3 D = ray.direction;
            float tca = VectorMath.Dot(L.Normalized(), D);

            if (tca < 0) return null;

            float d =  (Position - (ray.origin + D * tca * L.Length)).Length; 
            float thc = (float)Math.Sqrt(_radius * _radius + d * d);

            if (d < 0 || d > _radius) return null;

            Vector3 intersectionPoint = ray.origin + (tca - thc) * ray.direction;
            Vector3 normal = Vector3.Normalize(intersectionPoint - Position);
            return new Intersection(this, normal, ray);
        }
    }
}
