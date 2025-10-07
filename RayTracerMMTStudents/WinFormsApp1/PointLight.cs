using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUAS.MMT
{
    public class PointLight:Light
    {

        public PointLight(RTObject object_, double intensity_, Vector color_)
        {
            Object = object_;
            Intensity = intensity_;
            Color = color_;
        }

        public override double ComputeLighting(HitRecord hit_, Vector lookFrom_, Material mat_, List<RTObject> scene)
        {


            HitRecord shadow_hit = new HitRecord();

            Ray shadow_ray = new Ray(hit_.p, Object.Position - hit_.p);

            for (int i = 0; i < scene.Count; i++)
            {

                if (scene[i] != Object)
                {

                    if (scene[i].AMesh.Hit(shadow_ray, ref shadow_hit) && shadow_hit.t > 0)
                    {

                        return 0;

                    }

                }

            }


            double diffuse = 0;

            double specular = 0;

            //diffuse
            Vector L = Object.Position - hit_.p; //fixxme: use position w.r.t. hierarchy

            L = L.Normalize();

            //double nDotL = Vector.Dot(hit_.normal, L.Normalize());
            double NDotL = Vector.Dot(hit_.normal, L);
            if (NDotL >= 0)
            {
                diffuse = (Intensity * (NDotL));

            }

            //specular
            Vector R = (hit_.normal * 2 * NDotL) - L;
            R = R.Normalize();

            Vector C = lookFrom_;
            Vector V = C - hit_.p;
            V = V.Normalize();

            double RDotV = Vector.Dot(R, V);

            if (RDotV >= 0)
            {
                specular = Intensity * Math.Pow((RDotV), mat_.Specular);

            }


            return diffuse + specular;

        }

    }

}
