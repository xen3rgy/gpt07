using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public static class Utils
    {
        //conversion of degress to radians
        public static double DegToRad(double deg_)
        {
            return deg_ * Math.PI / 180.0;
        }


        //conversion of radians to degrees
        public static double RadToDeg(double rad_)
        {
            return rad_ * 180.0 / Math.PI;
        }


        public static double Clamp(double value, double min = 0, double max = 1)
        {

            if (value < min)
            {
                value = min;
            }

            if (value > max)
            {
                value = max;
            }

            return value;

        }

        //extract a vector from the string, separated by whitespace
        public static bool ParseStringVector(string s_, ref Vector v_)
        {
            string[] parts = s_.Split(' ');


            int idx = 0;
            foreach (string part in parts)
            {
                if (double.TryParse(part, out double number))
                {
                    if (idx == 0)
                        v_.X = number;

                    if (idx == 1)
                        v_.Y = number;

                    if (idx == 2)
                    {
                        v_.Z = number;
                        return true;
                    }

                }
                else

                {
                    return false;

                }

                idx++;

            }

            return false;

        }

        public static bool ParseStringDouble(string s_, ref double v_)
        {

            if (double.TryParse(s_, out double number))
            {
                v_ = number;
                return true;
            }

            return false;

        }


        public static byte [] LoadImage(string filename_, ref int width_, ref int height_)
        {

            try
            {
                Bitmap bmp = new Bitmap(filename_);
                if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
                {

                    height_ = bmp.Height;
                    width_ = bmp.Width;

                    byte [] buffer_ = new byte[width_ * height_ * 3];

                    for (int y = 0; y < bmp.Height; y++)
                    {

                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color c = bmp.GetPixel(x, y);

                            if (!(c.R == 0 && c.G == 0 && c.B == 0))
                            {
                                buffer_[y * 3 * width_ + x * 3 + 0] = c.R;
                                buffer_[y * 3 * width_ + x * 3 + 1] = c.G;
                                buffer_[y * 3 * width_ + x * 3 + 2] = c.B;
                            }

                        }

                    }

                    //BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);

                    ////Copy the data from the byte array into BitmapData.Scan0
                    //Marshal.Copy(buffer_, 0, bmpData.Scan0, buffer_.Length);

                    //bmp.UnlockBits(bmpData);


                    return buffer_;
                  
                }

            }
            catch (Exception e)
            {

            }

            return null;

        }



        public static byte[] BilinearInterpolateRGB(byte[] imageData, int width, int height, double x, double y)
        {
            // Bound coordinates within the image dimensions
            if (x < 0 || x > width - 1 || y < 0 || y > height - 1)
                throw new ArgumentException("Coordinates are outside the image bounds.");

            // Get the coordinates of the four surrounding pixels
            int x1 = (int)Math.Floor(x);
            int x2 = Math.Min(x1 + 1, width - 1); // Ensure we don't go out of bounds
            int y1 = (int)Math.Floor(y);
            int y2 = Math.Min(y1 + 1, height - 1); // Ensure we don't go out of bounds

            // Get the fractional parts
            double xFrac = x - x1;
            double yFrac = y - y1;

            // Interpolate each color channel separately: R, G, B
            byte[] interpolatedColor = new byte[3];

            for (int channel = 0; channel < 3; channel++)
            {
                // Retrieve the pixel values from the surrounding points for each channel
                byte Q11 = imageData[(y1 * width + x1) * 3 + channel]; // Top-left
                byte Q21 = imageData[(y1 * width + x2) * 3 + channel]; // Top-right
                byte Q12 = imageData[(y2 * width + x1) * 3 + channel]; // Bottom-left
                byte Q22 = imageData[(y2 * width + x2) * 3 + channel]; // Bottom-right

                // Perform bilinear interpolation for the current color channel
                double R1 = (1 - xFrac) * Q11 + xFrac * Q21; // Interpolation along x for the top row
                double R2 = (1 - xFrac) * Q12 + xFrac * Q22; // Interpolation along x for the bottom row
                double P = (1 - yFrac) * R1 + yFrac * R2;    // Interpolation along y

                // Clamp result to valid byte range [0, 255] and store in the result array
                interpolatedColor[channel] = (byte)Math.Clamp(P, 0, 255);
            }

            return interpolatedColor;
        }



        public static Vector Reflect(Vector direction_, Vector normal_)
        {
            return normal_ * 2 * Vector.Dot(normal_, direction_) - direction_;

        }


        public static List<int> GetSectionIndices(int height_, int sections_)
        {

            List<int> indices = new List<int>();
            if(height_ > 0 && sections_ > 0 && sections_ < height_)
            {

                int delta = height_ / sections_; //section length

                if (sections_ > 1) {

                    for (int i = 0; i < sections_-1; i++)
                    {

                        int start = (i * delta);

                        indices.Add(start);
                        indices.Add(start+delta-1);

                        start = indices[indices.Count - 1] + 1;
                    }

                    indices.Add(indices[indices.Count-1]+1);
                    indices.Add(height_ - 1);

                }
                else
                {

                    indices.Add(0);
                    indices.Add(height_-1);

                }
                
            }

            return indices;

        }

    }
}
