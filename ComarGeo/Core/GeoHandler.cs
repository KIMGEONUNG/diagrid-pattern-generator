using ComarGeo.Model;
using ComarGeo.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Core
{
    public class GeoHandler : Handler
    {
        #region MyRegion

        public GeoHandler():base()
        {

        }

        public GeoHandler(double epsilon) : base(epsilon)
        {

        }
        #endregion

        #region Method

        public PointPositionWithPolygon PointInPolygon(Point _pt, Polygon _poly)
        {

            //  Winding number algorithm ( fast implementation version)
            int wn = 0;    // the  winding number counter
            List<Point> V = _poly.Points;
            // loop through all edges of the polygon
            for (int i = 0; i < _poly.Count; i++)
            {   // edge from V[i] to  V[i+1]
                Line ln = new Line(V[i], V[(i + 1)%_poly.Count]);
                if (IsPointOnLine(_pt, ln)) return PointPositionWithPolygon.OnBoundary;

                if (V[i].Y <= _pt.Y) // start y <= P.y
                {
                    if (V[(i + 1) % _poly.Count].Y > _pt.Y)      // an upward crossing
                        if (LineBasedPointPosition(_pt, ln) == PointPositionWithLine.Left)  // P left of  edge
                            ++wn;            // have  a valid up intersect
                }
                else // V[i].Y > _pt.Y
                {                        // start y > P.y (no test needed)
                    if (V[(i + 1) % _poly.Count].Y <= _pt.Y)     // a downward crossing
                        if (LineBasedPointPosition(_pt, ln) == PointPositionWithLine.Left)  // P right of  edge
                            --wn;            // have  a valid down intersect
                }
            }

            if (wn == 0) return PointPositionWithPolygon.Outside;
            else return PointPositionWithPolygon.Inside;

        }

        public PointPositionWithLine LineBasedPointPosition(Point basePt, Line ln)
        {
            double ptY = basePt.Y;

            Point[] lnPts = { ln.From, ln.To };
            var pts = lnPts.OrderBy(n => n.Y).ThenBy(n => n.X).ToList();
            Vector lnVec = new Vector(pts[1] - pts[0]);
            Vector baseVec = new Vector(basePt - pts[0]);
            double d = Vector.CrossProduct(lnVec, baseVec);

            if (pts[0].Y <= ptY && ptY <= pts[1].Y) // inter Bound
            {
                if (_IsZero(d))
                    return PointPositionWithLine.OnTheLineOrHorizonal;
                else if (d > 0)
                {
                    return PointPositionWithLine.Left;
                }
                else return PointPositionWithLine.Right;
            }
            else return PointPositionWithLine.OutOfBoundary;
        }

        public bool IsPointOnLine(Point pt, Line ln)
        {
            Vector lnVec = new Vector(ln.To - ln.From); // AB->
            Vector ptVec = new Vector(pt - ln.From); // AC->

            double dotProduct1 = Vector.DotProduct(lnVec ,ptVec);
            double dotProduct2 = Vector.DotProduct(lnVec ,lnVec);

            double cross = Vector.CrossProduct(lnVec, ptVec);

            if (_IsZero(cross))
            {
                if (0 <= dotProduct1 && dotProduct1 <= dotProduct2)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
