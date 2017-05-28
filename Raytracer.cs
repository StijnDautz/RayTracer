using OpenTK;
using System;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;
        private Surface _surface;
        private int _rayCounter = 0; //So that not EVERY debug ray gets drawn
        private int maxReflection = 2;

        public Raytracer(Scene scene, Camera camera, Surface surface)
        {
            _scene = scene;
            _camera = camera;
            _surface = surface;
        }

        public void Render()
        {
            for (int x = 0; x < 512; x++) //instead of 0 -> resolution.X
            {
                for (int y = 0; y < 512; y++)
                {
                    //TODO how to assign a color to a pixel, cast shadow ray function returns color and alle colors for one pixel are added to one color?
                    //TODO re add magnitude variable to constructer to preven direction vector * 10
                    _surface.pixels[x + y * 1024] = VectorMath.GetColorInt(TraceRay(new VectorMath.Ray(_camera.Position, (_camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position) * 10), 0));  
                }
            }

            //draw the primivites in the scene over the casted rays
            _surface.DrawPrimitives(_scene.Primitives, _scene.Lights, _camera.Screen);
        }

        private Vector3 DirectIllumination(Vector3 intersectionPoint, Vector3 normal, Light light)
        {
            Vector3 L = light.Position - intersectionPoint;
            float dist = L.Length;
            L *= (1.0f / dist);
            float attenuation = 1 / (dist * dist);
            return light.Color * VectorMath.Dot(normal, L) * attenuation * light.Intensity;
        }
        private Vector3 TraceRay(VectorMath.Ray ray, int reflectionNum)
        {
            if (reflectionNum < maxReflection)
            {
                //Cast a ray from the camera through a point on the 2D screen and find the primitive in the world it hits first
                Intersection intersection = _scene.GetClosestIntersection(ray);

                if (ray.direction.Y == 0)
                {
                    if (_rayCounter % 105 == 0)
                    {
                        if (intersection == null) _surface.DrawRay(ray, _camera.Screen, ray.magnitude, new Vector3(1f,0f,0f));
                        else _surface.DrawRay(ray, _camera.Screen, intersection.Distance, new Vector3(1f,0f,0f) );
                    }
                    if (reflectionNum == 0) _rayCounter++;
                }

                if (intersection == null)
                {
                    return Vector3.Zero; //Zwerte kleur als hij niks raakt
                }
                else
                {
                    /*if (!intersection.primitive.IsMirror)
                    {
                        //cast shadow ray
                        //TODO create cast shadow ray function that returns a color?
                    }*/
                    
                    //If reflective:
                    //calculate the reflected ray and trace this ray too -> recursion
                    //Vector3 reflection = VectorMath.Reflect(ray.direction, intersection.Normal);
                    //TraceRay(new VectorMath.Ray(ray.origin + ray.direction * intersection.Distance, reflection), ++reflectionNum);
                    
                    //If glass:
                    if (intersection.primitive.IsGlass)
                    {
                        //return TraceRay(new VectorMath.Ray(intersection.Distance * ray.direction + ray.origin, ;
                    }

                    //Console.WriteLine(VectorMath.Dot(_scene.Lights[0].Position - ray.origin + ray.direction * intersection.Distance, intersection.Normal));
                    return intersection.primitive.Color * DirectIllumination(intersection.IntersectionPoint, intersection.Normal, _scene.Lights[0]);  //Kek kleurtje als hij wél iets raakt
                    //cast shadowRays
                    //TODO call _screen.CastShadowRays
                }
            }
            return Vector3.Zero;
        }

        private int Vector3D(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
}