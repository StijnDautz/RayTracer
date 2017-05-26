using OpenTK;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;
        private bool _debugMode;

        public void Render()
        {
            Point resolution = _camera.Screen.Resolution;
            for (int x = 0; x < resolution.X; x++)
            {
                for (int y = 0; y < resolution.Y; y++)
                {
<<<<<<< HEAD
                    //TODO how to assign a color to a pixel, cast shadow ray function returns color and alle colors for one pixel are added to one color?
                    TraceRay(new VectorMath.Ray(_camera.Position, _camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position, 100));
=======
                    TraceRay(new VectorMath.Ray(_camera.Position, _camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position));
>>>>>>> origin/Jacco_v2
                }
            }
        }

        private void TraceRay(VectorMath.Ray ray)
        {
            //Cast a ray from the camera through a point on the 2D screen and find the primitive in the world it hits first
            Intersection intersection = _scene.GetClosestIntersection(ray);

            //if in debugMode draw this vector in the debugwindow
            if(_debugMode)
            {
                
            }
            if (!intersection.primitive.IsMirror)
            {
                //cast shadow ray
                //TODO create cast shadow ray function that returns a color?
            }
            //calculate the reflected ray and trace this ray too -> recursion
            Vector3 reflection = VectorMath.Reflect(ray.direction, intersection.Normal);
<<<<<<< HEAD
            TraceRay(new VectorMath.Ray(intersection.Ray.Position, reflection, reflection.Length));
=======
            TraceRay(new VectorMath.Ray(intersection.Position, reflection));
>>>>>>> origin/Jacco_v2
        }
    }
}