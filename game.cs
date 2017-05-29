using OpenTK;
using System;
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
            _random = new Random();

            Scene scene = new Scene();
            scene.AddPrimitive(new Sphere(new Vector3(2, 0, 4), 1, new Vector3(1.0f, 0.5f, 0.5f)));      
            scene.AddPrimitive(new Sphere(new Vector3(4, 0, 3), 1, new Vector3(0.5f, 1.0f, 0.5f)));
            scene.AddPrimitive(new Sphere(new Vector3(-1, 0, 3), 1, new Vector3(0.5f, 0.5f, 1.0f)));
            scene.AddPrimitive(new Plane(new Vector3(0, -1, 0), new Vector3(0, 1, 0), new Vector3(1f, 1f, 1f)));
            scene.AddPrimitive(new Plane(new Vector3(0, 5, 0), new Vector3(0, -1, 0), new Vector3(1f, 1f, 1f)));
            scene.AddPrimitive(new Plane(new Vector3(-4, 0, 0), new Vector3(1, 0, 0), new Vector3(1f, 1f, 1f)));
            scene.AddPrimitive(new Plane(new Vector3(6, 0, 0), new Vector3(-1, 0, 0), new Vector3(1f, 1f, 1f)));
            scene.AddPrimitive(new Plane(new Vector3(0, 0, 5f), new Vector3(0, 0, -1), new Vector3(2f, 2f, 2f)));       
            scene.AddLight(new Light(new Vector3(0, 1, 0), new Vector3(1f, 1f, 1f), new Vector3(3f,3f,3f)));

            Screen scr = new Screen(new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Point(512, 512), new Point(8, 8));
            Camera camera = new Camera(new Vector3(0, 0, -2), new Vector3(0, 0, 1), scr);
            _raytracer = new Raytracer(scene, camera, surface);
        }

	    // tick: renders one frame
	    public void Tick()
	    {
		    surface.Clear( 0 );
            _raytracer.Render();
	    }
    }
}