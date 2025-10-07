using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace CUAS.MMT
{

    public struct HitRecord
    {

        public Vector p; //intersection point
        public Vector normal;
        public double t; //ray parameter
        public RTObject? obj = null;

        public HitRecord()
        {

            p = new Vector();
            normal = new Vector();
            t = double.PositiveInfinity;

        }

    }


    interface IHittable
    {
        bool Hit(Ray ray_, ref HitRecord record_);

    }


    internal class RayTracer
    {

       
        int width = 0;
        int height = 0;

        byte[] buffer = {0}; //internal buffer for creating the image (~canvas coord., y down)

        double cFOV = 90; //vertical field of view

        Vector lookFrom = new Vector(0, 0, 0);   // Point camera is looking from (its center)

        double cFocalLength = 1f; //will be set automatically, if required

        Vector lookAt = new Vector(0, 0, -1);  // Point camera is looking at
        Vector vUp = new Vector(0, 1, 0);     // Camera-relative "up" direction

        double vHeight = 2.0f; //viewport height (will be set automatically)
        double vWidth = 2.0f; //viewport width (will be set automatically)

        //vectors across the horizontal and down the vertical viewport edges.
        Vector vU = new Vector();
        Vector vV = new Vector();

        //Horizontal and vertical delta vectors from pixel to pixel
        Vector vPixelDeltaU = new Vector();
        Vector vPixelDeltaV = new Vector();

        //Location of the upper left pixel
        Vector vUpperLeft = new Vector();
        
        //start pixel location on viewport
        Vector vPixel00Loc = new Vector();

        int maxDepth = 3; //max. depth for ray tracing


        public RayTracer() {

            //Console.WriteLine("RayTracer"); //will not be visible in a forms app.
        }


        public bool Init(int width_, int height_, Vector look_from_, Vector look_at_, Vector up_, double fov_ = 90.0)
        {

            if (width_ > 0 && height_ > 0 && fov_ > 0)
            {

                width = width_;
                height = height_;

                buffer = new byte[width * height * 3];

                var span = new Span<byte>(buffer);

                span.Fill(128);

                //for (int y = 0; y < height; y++)
                //{
                //    for (int x = 0; x < width; x++)
                //    {

                //        buffer[y * width * 3 + x * 3] = 128;
                //        buffer[y * width * 3 + x * 3 + 1] = 128;
                //        buffer[y * width * 3 + x * 3 + 2] = 128;
                //    }
                //}

                //viewport setup


                ////standard
                //vWidth = vHeight * width_ /(double)height;

                ////adjustable FOV
                cFOV = fov_;

                //double theta = Utils.DegToRad(cFOV);
                //double h = Math.Tan(theta / 2);
                //vHeight = 2 * h * cFocalLength;
                //vWidth = vHeight * (double)width / (double)height;


                //// Calculate the vectors across the horizontal and down the vertical viewport edges.
                //vU = new Vector(vWidth, 0, 0);
                //vV = new Vector(0, -vHeight, 0);

                //// Calculate the horizontal and vertical delta vectors from pixel to pixel.
                //vPixelDeltaU = vU / (double)width;
                //vPixelDeltaV = vV / (double)height;

                //// Calculate the location of the upper left pixel.
                //vUpperLeft = lookFrom - new Vector(0, 0, cFocalLength) - vU / 2.0 - vV / 2.0;

                //vPixel00Loc = vUpperLeft + (vPixelDeltaU + vPixelDeltaV) * 0.5;


                //custom camera position and orientation

                lookFrom = look_from_;
                lookAt = look_at_;
                vUp = up_;


                cFocalLength = (lookFrom - lookAt).Length();
                //double theta = cFOV * Math.PI / 180.0;
                double theta = Utils.DegToRad(cFOV);
                double h = Math.Tan(theta / 2);
                vHeight = 2 * h * cFocalLength;
                vWidth = vHeight * (double)width / (double)height;

                // Calculate the u,v,w unit basis vectors for the camera coordinate frame.
                Vector w = (lookFrom - lookAt).Normalize(); //away from viewing ray

                Vector u = Vector.Cross(vUp, w).Normalize();
                Vector v = Vector.Cross(w, u);

                // Calculate the vectors across the horizontal and down the vertical viewport edges.
                vU = u * vWidth;    // Vector across viewport horizontal edge
                vV = v * (-1) * vHeight;  // Vector down viewport vertical edge

                // Calculate the horizontal and vertical delta vectors from pixel to pixel.
                vPixelDeltaU = vU / (double)width;
                vPixelDeltaV = vV / (double)height;

                // Calculate the location of the upper left pixel.
                vUpperLeft = lookFrom - (w * cFocalLength) - vU / 2.0 - vV / 2.0; //custom camera pos and orient.

                vPixel00Loc = vUpperLeft + (vPixelDeltaU + vPixelDeltaV) * 0.5;


                return true;

            }

            else
            {

                return false;

            }

        }

        //@param max_depth_ recursion depth
        public bool Render(List<RTObject> scene, int max_depth_ = 1)
        {

            if (width > 0 && height > 0) //initialized
            {

                maxDepth = max_depth_;

                //determine light sources...
                List<RTObject> lights = new List<RTObject>();
                List<RTObject> meshes = new List<RTObject>();

                for (int i = 0; i < scene.Count; i++)
                {
                    if (scene[i].ALight != null)
                    {

                        lights.Add(scene[i]);

                    }
                    else if (scene[i].AMesh != null)
                    {

                        meshes.Add(scene[i]);

                    }

                }

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Vector pixel_center = vPixel00Loc + (vPixelDeltaU * x) + (vPixelDeltaV * y);
                        Vector ray_direction = pixel_center - lookFrom;
                        var ray = new Ray(lookFrom, ray_direction);
                        int depth = 0; //current depth
                        Vector color = TraceRay(ray, meshes, lights, depth);

                        buffer[y * width * 3 + x * 3 + 0] = (byte)(Utils.Clamp(color.Z) * 255);
                        buffer[y * width * 3 + x * 3 + 1] = (byte)(Utils.Clamp(color.Y) * 255);
                        buffer[y * width * 3 + x * 3 + 2] = (byte)(Utils.Clamp(color.X) * 255);

                    }

                }

                return true;

            }

            return false;

        }


        public RTObject GetObject(List<RTObject> scene, Point point)
        {

            int x = point.X;
            int y = point.Y;

            Vector pixel_center = vPixel00Loc + (vPixelDeltaU * x) + (vPixelDeltaV * y);
            Vector ray_direction = pixel_center - lookFrom;
            var ray = new Ray(lookFrom, ray_direction);

            //determine closest hit
            HitRecord closest_hit = new HitRecord();
            HitRecord tmp = new HitRecord();
            for (int i = 0; i < scene.Count; i++)
            {

                if (scene[i].AMesh != null)
                {
                    if (scene[i].AMesh.Hit(ray, ref tmp))
                    {
                        if (tmp.t < closest_hit.t)
                        {
                            closest_hit = tmp;
                        }
                    }

                }

            }

            if (closest_hit.t != double.PositiveInfinity && closest_hit.t > 0)
            {

                return closest_hit.obj;

            }

            return null;

        }


        public byte[] GetBuffer()
        {

            return buffer;

        }


        //depth_ recursion depth
        private Vector TraceRay(Ray ray_, List<RTObject> scene_, List<RTObject> lights_, int depth_) 
        {

            //determine closest hit
            HitRecord closest_hit = new HitRecord();

            HitRecord tmp = new HitRecord();
            for (int i = 0; i < scene_.Count; i++)
            {
                if (scene_[i].AMesh != null)
                {
                    if (scene_[i].AMesh.Hit(ray_, ref tmp))
                    {
                        if (tmp.t < closest_hit.t)
                        {
                            closest_hit = tmp;
                        }
                    }
                }

            }


            if (closest_hit.t != double.PositiveInfinity && closest_hit.t > 0)
            {
                Material mat = (Material)closest_hit.obj.AMaterial;

                Vector lightValue = new Vector();

                if (mat != null)
                {
                    for (int i = 0; i < lights_.Count; i++)
                    {
                        lightValue += lights_[i].ALight.Color * lights_[i].ALight.ComputeLighting(closest_hit, lookFrom, mat, scene_);

                    }

                }

                Vector c = mat.Color;

                if(mat.BaseMap != null)
                {

                    double u = 0;
                    double v = 0;

                    closest_hit.obj.AMesh.UV(closest_hit, ref u, ref v);

                    double r = 0;
                    double g = 0;
                    double b = 0;

                    mat.SampleBaseMap(u, v, ref r, ref g, ref b);

                    c.X = r; c.Y = g; c.Z = b;  

                }

                Vector local_color = new Vector(c.X * lightValue.X, c.Y * lightValue.Y, c.Z * lightValue.Z);

                return local_color;

                if (depth_ == maxDepth || mat.Reflective <= 0)
                {
                    return local_color;
                }

                Vector direction_in = ray_.Direction;//.Normalize();

                Vector direction_out = Utils.Reflect(ray_.Direction.Normalize(), closest_hit.normal);
                direction_out = direction_out.Normalize();
                direction_out.X = direction_out.X * -1; //invert
                direction_out.Y = direction_out.Y * -1;
                direction_out.Z = direction_out.Z * -1;

                Ray ray_n = new Ray(closest_hit.p, direction_out);

                Vector reflected_color = TraceRay(ray_n, scene_, lights_, depth_ + 1);

                return local_color * (1 - mat.Reflective) + reflected_color * mat.Reflective;

            }


            if (depth_ == 0)
            {
                //background
                Vector unit_direction = ray_.Direction.Normalize();
                double a = (unit_direction.Y + 1.0) * 0.5; //range: 0..1
                return new Vector(1, 1, 1) * (1 - a) + new Vector(0.5, 0.7, 1) * a;
            }
            else
            {

                return new Vector(0, 0, 0);

            }

        }

    }

}
