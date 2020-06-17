using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Primitive
{
    [DebuggerDisplay("X : {X} , Y : {Y}")]
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector(Point pt)
        {
            X = pt.X;
            Y = pt.Y;
        }

        #region Static Method

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y);
        }

        public static Vector operator *(Vector a, double b)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector operator *(double b, Vector a)
        {
            return new Vector(a.X * b, a.Y * b);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

        public static double CrossProduct(Vector a, Vector b)
        {
            double z = a.X * b.Y - b.X * a.Y;

            return z;
        }

        public static double DotProduct(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        #endregion
    }
}
