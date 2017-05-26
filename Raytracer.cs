using OpenTK;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;

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
        }

        public void Render()
        {
            Point resolution = _camera.Screen.Resolution;
            for(int x = 0; x < resolution.X; x++)
            {
                for(int y = 0; y < resolution.Y; y++)
                {
                    //Cast a ray from the camera through a point on the 2D screen and find the primitive in the world it hits first
                    _scene.GetClosestIntersection(new Ray(_camera.Position, _camera.Screen.ConvertToWorldCoords(new Point(x, y)) - _camera.Position, 100));
                }
            }
        }
    }
}