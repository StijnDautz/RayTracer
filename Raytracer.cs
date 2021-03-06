﻿using OpenTK;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;
        private Surface _surface;
        private int _rayCounter = 0; //So that not EVERY ray gets drawn
        private int maxReflection = 4;

        public Raytracer(Scene scene, Camera camera, Surface surface)
        {
            _scene = scene;
            _camera = camera;
            _surface = surface;
        }

        public void Render()
        {
            Point resolution = _camera.Screen.Resolution;
            for (int x = 0; x < resolution.X; x++) //instead of 0 -> resolution.X
            {
                for (int y = 0; y < resolution.Y; y++)
                {
                    //TODO how to assign a color to a pixel, cast shadow ray function returns color and alle colors for one pixel are added to one color?
                    //TODO re add magnitude variable to constructer to preven direction vector * 10
                    TraceRay(new VectorMath.Ray(_camera.Position, (_camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position) * 10), 0);
                }
            }

            //draw the primivites in the scene over the casted rays
            _surface.DrawPrimitives(_scene.Primitives, _camera.Screen);
        }

        private void TraceRay(VectorMath.Ray ray, int reflectionNum)
        {
            //Cast a ray from the camera through a point on the 2D screen and find the primitive in the world it hits first
            Intersection intersection = _scene.GetClosestIntersection(ray);


            if (intersection != null) //Dynamic Debug Mode
            {
                if (ray.direction.Y == 0)
                {
                    //if (_rayCounter % 10 == 0)
                    //{
                        _surface.DrawRay(ray, _camera.Screen, intersection.Distance);
                    //}
                    //_rayCounter++;
                }

                /*if (!intersection.primitive.IsMirror)
                {
                    //cast shadow ray
                    //TODO create cast shadow ray function that returns a color?
                }*/
                //calculate the reflected ray and trace this ray too -> recursion
                Vector3 reflection = VectorMath.Reflect(ray.direction, intersection.Normal);
                TraceRay(new VectorMath.Ray(intersection.Ray.Position, reflection), ++reflectionNum);            
            }
        }
    }
}