using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public class Ray
    {
        public Vector Origin { get; }

        public Vector Direction { get; }

        double RefractionIndex { get; set; } = 1.0;

        public Ray(Vector origin, Vector direction)
        {
            Origin = origin;
            Direction = direction;
        }
    }

}
