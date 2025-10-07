using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUAS.MMT
{

    public class Sphere : Mesh
    {

        //geometry
        public double Radius { get; set; }

        public Vector Center{ get; set; }

        public Sphere(RTObject object_, Vector center_, double radius_)
        {
            Object = object_;
            Center = center_;
            Radius = radius_;
   
        }

        public override bool Hit(Ray ray_, ref HitRecord record_)
        {

            //fixxme: update center according to hierarchy
            Vector center = Object.Position + Center;


            Vector oc = ray_.Origin - center;
            double a = Vector.Dot(ray_.Direction, ray_.Direction);
            double b = 2.0 * Vector.Dot(oc, ray_.Direction);
            double c = Vector.Dot(oc, oc) - Radius * Radius;
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {

                record_.t = (-b - Math.Sqrt(discriminant)) / (2.0 * a);

                if (record_.t >= 0)
                {

                    record_.p = ray_.Origin + ray_.Direction * record_.t;
                    record_.normal = (record_.p - center).Normalize(); //surface normal for spheres
                    record_.obj = Object;
                    return true;

                }
            }

            record_.t = 0; //no intersection

            return false;

        }

        public override void UV(HitRecord hit_, ref double u_, ref double v_){


            //get u, v coordinates; fixxme: put into a function of the mesh
            Vector r_vec = hit_.p - hit_.obj.Position;
            double r = r_vec.Length();
            double theta = Math.Acos(r_vec.Y / r);
            double phi = Math.Atan2(r_vec.Z, r_vec.X);

            u_ = (-phi + Math.PI) / (2 * Math.PI);
            v_ = theta / Math.PI;


        }

    }

}
