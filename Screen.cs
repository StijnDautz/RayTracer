using OpenTK;
using System.Drawing;

namespace template
{
    class Screen : Plane
    {
        private Point _resolution;
        Vector3[] corners = new Vector3[4];

        public Point Resolution
        {
            get { return _resolution; }
        }

        private Vector3 TopLeft
        {
            get { return corners[0]; }
        }

        private Vector3 TopRight
        {
            get { return corners[1];  }
        }

        private Vector3 BottomLeft
        {
            get { return corners[2]; }
        }

        private Vector3 BottomRight
        {
            get { return corners[3]; }
        }

        public Screen(Vector3 position, Vector3 normal, Point resolution) : base(position, normal)
        {
            _resolution = resolution;
        }

        public Vector3 ConvertToWorldCoords(Point p)
        {
            //given a positional vector v1 and two directional vectors v2 and v3, which determine a plane, any point on this plane can be defined by v1 + t1 * v2 + t2 * v3
            return TopLeft + ((TopRight - TopLeft) / _resolution.X) * p.X + ((BottomLeft - TopLeft) / _resolution.Y) * p.Y;
        }
    }
}
