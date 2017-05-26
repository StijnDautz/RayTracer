using OpenTK;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;

        public void Render()
        {
            Point resolution = _camera.Screen.Resolution;
            for (int x = 0; x < resolution.X; x++)
            {
                for (int y = 0; y < resolution.Y; y++)
                {
                    TraceRay(new VectorMath.Ray(_camera.Position, _camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position));
                }
            }
        }

        private void TraceRay(VectorMath.Ray ray)
        {
            //Cast a ray from the camera through a point on the 2D screen and find the primitive in the world it hits first
            Intersection intersection = _scene.GetClosestIntersection(ray);
            if (!intersection.primitive.IsMirror)
            {
                //cast shadow ray
            }
            //calculate the reflected ray and trace this ray too -> recursion
            Vector3 reflection = VectorMath.Reflect(ray.direction, intersection.Normal);
            TraceRay(new VectorMath.Ray(intersection.Position, reflection));
        }
    }
}