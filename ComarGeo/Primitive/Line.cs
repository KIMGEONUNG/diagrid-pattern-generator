using ComarGeo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Primitive
{
    public struct Line
    {
        public Point From { get; }
        public Point To { get; }

        public Line(double startX, double startY, double endX, double endY)
        {
            From = new Point(startX, startY);
            To = new Point(endX, endY);
        }

        public Line(Point from, Point to)
        {
            From = from;
            To = to;
        }

    }
}
