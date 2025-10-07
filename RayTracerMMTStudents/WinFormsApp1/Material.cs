using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public class Material
    {

        public RTObject? Object = null;

        public Vector Color { get; set; } //base color

        public double Specular { get; set; }

        public double Reflective { get; set; }

        public double RefractionIndex { get; set; }

        public byte[]? BaseMap = null;
        public int BaseMapWidth = 0;
        public int BaseMapHeight = 0;


        //public Material(Material mat_) //copy constructor
        //{
        //    Object = mat_.Object;
        //    Color = mat_.Color;
        //    Specular = mat_.Specular;
        //    Reflective = mat_.Reflective;
        //    RefractionIndex = mat_.RefractionIndex;

        //    BaseMapWidth = mat_.BaseMapWidth;
        //    BaseMapHeight = mat_.BaseMapHeight;

        //    BaseMap = null;
        //    if (mat_.BaseMap != null)
        //    {
        //        BaseMap = new Byte[mat_.BaseMap.Length];
        //        mat_.BaseMap.CopyTo(BaseMap, 0);
        //    }

        //}


        public bool SampleBaseMap(double u_, double v_, ref double r_, ref double g_, ref double b_, bool bilinear_ = true)
        {

            if (!(BaseMap == null || BaseMapHeight <= 0 || BaseMapWidth <= 0))
            {

                //->map to pixel coordinates
                double xi = u_ * (BaseMapWidth - 1);
                double yi = v_ * (BaseMapHeight - 1);



                if (bilinear_)
                {
                    //-----------------------------------------------------------------------------------
                    //bilinear
                    byte[] value = Utils.BilinearInterpolateRGB(BaseMap, BaseMapWidth, BaseMapHeight, xi, yi);
                    r_ = value[0] / 255.0;
                    g_ = value[1] / 255.0;
                    b_ = value[2] / 255.0;
                }
                else
                {

                    //-----------------------------------------------------------------------------------
                    //nearest neighbor
                    int idx = (int)(yi) * 3 * BaseMapWidth + (int)xi * 3;

                    if (idx >= 0 && idx + 2 < BaseMap.Length)
                    {

                        r_ = BaseMap[idx + 0] / 255.0;
                        g_ = BaseMap[idx + 1] / 255.0;
                        b_ = BaseMap[idx + 2] / 255.0;

                    }

                }

                return true;
            }

            return false;


        }


        public Material(RTObject object_, Vector color_)
        {

            Object = object_;

            Color = color_;

            Specular = 200; //shiny
            Reflective = 0.3f;
            RefractionIndex = 1.00f;  //refraction index (water: 1.33f, air: 1.0003f)

        }


        public Material(RTObject object_, Vector color_, double specular_ = 200, double reflective_ = 0.3, double refraction_ = 1.00f)
        {

            Object = object_;

            Color = color_;

            Specular = specular_;

            Reflective = reflective_;

            RefractionIndex = refraction_;

        }

    }
}
