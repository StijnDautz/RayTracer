using OpenTK;
using System.Collections.Generic;
using System.Drawing;

namespace template {

    class Game
    {
	    // member variables
	    public Surface surface;
        private Raytracer _raytracer;

	    // initialize
	    public void Init()
	    {
            List<Light> lights = new List<Light>();
            List<Primitive> primitives = new List<Primitive>();
            primitives.Add(new Sphere(new Vector3(0, 0, 4), 1, 255000000f));
            primitives.Add(new Sphere(new Vector3(-3, 0, 2), 1, 255000000f));

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