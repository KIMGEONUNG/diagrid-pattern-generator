using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Primitive
{
    [DebuggerDisplay("X : {X} , Y : {Y}")]
    public struct Point
    {
        public double X { get; }
        public double Y { get; }

        #region Constructor

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
        }
        #endregion

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }

        public static Point Unset => new Point(double.MinValue, double.MinValue);
    }
}
