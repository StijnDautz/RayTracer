using OpenTK;
using OpenTK.Input;

namespace template
{
    class Application
    {
        private static float scalar = 0.1f;
        private static Vector3 mousePosition;
        public static void handleInput(Camera camera)
        {
            var keyboardState = Keyboard.GetState();
            if (keyboardState[Key.Left])
            {
                camera.Position += new OpenTK.Vector3(-scalar, 0, 0);
                camera.Screen.Position += new OpenTK.Vector3(-scalar, 0, 0);
            }
            if (keyboardState[Key.Right])
            {
                camera.Position += new OpenTK.Vector3(scalar, 0, 0);
                camera.Screen.Position += new OpenTK.Vector3(scalar, 0, 0);
            }
            if (keyboardState[Key.Up])
            {
                camera.Position += new OpenTK.Vector3(0, 0, scalar);
                camera.Screen.Position += new OpenTK.Vector3(0, 0, scalar);
            }
            if (keyboardState[Key.Down])
            {
                camera.Position += new OpenTK.Vector3(0, 0, -scalar);
                camera.Screen.Position += new OpenTK.Vector3(0, 0, -scalar);
            }

            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton == ButtonState.Pressed)
            {
                if (mouse.X - 256 > 0) camera.Screen.MoveCameraX(0.1f);
                else camera.Screen.MoveCameraX(0.1f);
            }
            
        }

    }
}
