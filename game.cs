using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace template {

    class Game
    {
	    // member variables
	    public Surface surface;
        private Raytracer _raytracer;
        private Random _random;

	    // initialize
	    public void Init()
	    {
            List<Light> lights = new List<Light>();
            List<Primitive> primitives = new List<Primitive>();
            _random = new Random();
            primitives.Add(new Sphere(new Vector3(2, 0, 4), 1, new Vector3(1.0f, 0.5f, 0.5f)));
            primitives.Add(new Sphere(new Vector3(4, 0, 3), 1, new Vector3(0.5f, 1.0f, 0.5f)));
            primitives.Add(new Sphere(new Vector3(-1, 0, 3), 1, new Vector3(0.5f, 0.5f, 1.0f)));
            primitives.Add(new Plane(new Vector3(0, -2, 0), new Vector3(0, 1, 0), new Vector3(1f, 1f, 1f)));
            primitives.Add(new Plane(new Vector3(0, 4, 0), new Vector3(0, -1, 0), new Vector3(1f, 1f, 1f)));
            primitives.Add(new Plane(new Vector3(-5, 0, 0), new Vector3(1, 0, 0), new Vector3(1f, 1f, 1f)));
            primitives.Add(new Plane(new Vector3(5, 0, 0), new Vector3(-1, 0, 0), new Vector3(1f, 1f, 1f)));
            primitives.Add(new Plane(new Vector3(0, 0, 4.5f), new Vector3(0, 0, -1), new Vector3(1f, 1f, 1f)));

            lights.Add(new Light(new Vector3(4, 0, 1), new Vector3(1f, 1f, 1f), new Vector3(1.5f,1.5f,1.5f)));
            lights.Add(new Light(new Vector3(-3, 0, 1), new Vector3(1f, 1f, 1f), new Vector3(1.5f, 1.5f, 1.5f)));

            Scene scene = new Scene(lights, primitives);
            Screen scr = new Screen(new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Point(512, 512), new Point(8, 8));
            Camera camera = new Camera(new Vector3(0, 0, -1), new Vector3(0, 0, 1), scr);
            _raytracer = new Raytracer(scene, camera, surface);
        }

	    // tick: renders one frame
	    public void Tick()
	    {
		    surface.Clear( 0 );
            _raytracer.Render();
		    surface.Print( "hello world", 2, 2, 0xffffff );
	    }
    }
}