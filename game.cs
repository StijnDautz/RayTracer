using OpenTK;
using System.Drawing;

namespace template {

    class Game
    {
	    // member variables
	    public Surface screen;
        private Raytracer _raytracer;

	    // initialize
	    public void Init()
	    {
            Scene scene = new Scene();
            Screen screen = new Screen(new Vector3(0, 0, 1), new Vector3(0, 0, 1), new Point(512, 512));
            Camera camera = new Camera(new Vector3(0, 0, 0), new Vector3(0, 0, 1), screen);
            _raytracer = new Raytracer(scene, camera);
        }

	    // tick: renders one frame
	    public void Tick()
	    {
		    screen.Clear( 0 );
            _raytracer.Render();
		    screen.Print( "hello world", 2, 2, 0xffffff );
            screen.Line(2, 20, 160, 20, 0xff0000);
	    }
    }
}