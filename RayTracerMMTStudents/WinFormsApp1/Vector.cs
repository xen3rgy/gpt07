using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUAS.MMT
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector Normalize()
        {
            double length = Length();
            return new Vector(X / length, Y / length, Z / length);
        }

        public double Length()
        {
            double length = Math.Sqrt(X * X + Y * Y + Z * Z);
            return length;
     
        }

        public override string ToString()
        {
            return "Vector: " + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString();

        }


        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector operator *(Vector a, double b) => new Vector(a.X * b, a.Y * b, a.Z * b);

        public static Vector operator /(Vector a, double b) => new Vector(a.X / b, a.Y / b, a.Z / b);

        public static double Dot(Vector a, Vector b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z; //dot (inner) product)

        public static Vector Cross(Vector a, Vector b) => new Vector(a.Y*b.Z - a.Z*b.Y, a.Z*b.X - a.X*b.Z, a.X*b.Y - a.Y*b.X); //cross product


   

    }
}
