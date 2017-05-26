using OpenTK;

namespace template
{
    class Light
    {
        Vector3 location;
        Vector3 intensity; //Stores color in Vector3(R,G,B)

        public Light(Vector3 location, Vector3 intensity)
        {
            this.location = location;
            this.intensity = intensity;
        }
    }
}
