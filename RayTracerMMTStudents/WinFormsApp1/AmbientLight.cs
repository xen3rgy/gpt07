using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public class AmbientLight:Light
    {


        public AmbientLight(RTObject object_, double intensity_, Vector color_)
        {
            Object = object_;
            Intensity = intensity_;
            Color = color_;
        }

        public override double ComputeLighting(HitRecord hit_, Vector lookFrom_, Material mat_, List<RTObject> scene)
        {
            //diffuse

            double lightIntensity = Intensity;

            return lightIntensity;

        }

    }

}
