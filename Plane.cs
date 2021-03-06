﻿using OpenTK;
using System.Drawing;

namespace template
{
    public class Plane : Primitive
    {
        private Vector3 _normal;
        
        public Plane(Vector3 position, Vector3 normal, float color = 000000000f) : base(position, color)
        {
            _normal = normal;
        }

        public override Intersection GetIntersection(VectorMath.Ray ray)
        {
            //if the ray is not parralel to the plane, calculate the intersection point
            if(VectorMath.Dot(_normal, ray.direction) != 0)
            {
                Vector3 p = ray.origin + (-(VectorMath.Dot(ray.origin, _normal) + Position.Length) / VectorMath.Dot(ray.direction, _normal)) * ray.direction;
                return new Intersection(this, _normal, ray, (p - ray.origin).Length);
            }
            else { return null; }
        }
    }
}
