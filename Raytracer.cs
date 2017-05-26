using OpenTK;
using System.Collections.Generic;
using System.Drawing;

namespace template
{
    class Raytracer
    {
        private Scene _scene;
        private Camera _camera;
        private Screen _screen;

        public Color[,] CreatePixelArray()
        {
            List<Primitive> primitives = new List<Primitive>();
            primitives.Add(new Sphere(new Vector3(1, 0, 1), 1));
            primitives.Add(new Sphere(new Vector3(4, 0, 1), 1));
            primitives.Add(new Sphere(new Vector3(7, 0, 1), 1));
            Scene scene = new Scene(new List<Light>(), primitives);

            Color[,] pixelArray = new Color[_screen.Resolution.X, _screen.Resolution.Y];
            if (Application.debug)
            {
                //Draw circles
                for (int x = 0; x < pixelArray.GetLength(0); x++)
                {
                    for (int y = 0; y < pixelArray.GetLength(1); y++)
                    {
                        for (int i = 0; i < scene.primitives.Count; i++)
                        {
                            if(scene.primitives[i] is Sphere)
                            {
                                if (((x - scene.primitives[i].Position.X) * (x - scene.primitives[i].Position.X) + (y - scene.primitives[i].Position.Y) * (y - scene.primitives[i].Position.Y)) == (scene.primitives[i] as Sphere).Radius)
                                {
                                    pixelArray[x, y] = Color.Red;
                                }
                            }
                        }
                    }
                }
            }
            return pixelArray;
        }

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