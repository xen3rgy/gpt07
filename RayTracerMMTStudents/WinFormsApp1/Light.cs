using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public abstract class Light
    {

        public RTObject? Object;

        public double Intensity { get; set; }

        public Vector Color { get; set; }

        public Light(): base()
        {
            Intensity = 0.5;
            Color = new Vector(1, 1, 1);

        }

        public Light(double intensity_, Vector color_): base()
        {
            Intensity = 0.5;
            Color = color_;
        }

        public virtual double ComputeLighting(HitRecord hit_, Vector lookFrom_, Material mat_, List<RTObject> scene)
        {
            return 0;

        }

    }

}
