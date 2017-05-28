using OpenTK;

namespace template
{
    public class Light : Object
    {
        Vector3 intensity; //Stores color in Vector3(R,G,B)

        public Light(Vector3 position, Vector3 color, Vector3 intensity) : base(position, color)
        {
            this.intensity = intensity;
        }
    }
}
