using ComarGeo.Model;
using ComarGeo.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Core
{
    public class LineHandler : Handler
    {
        [Obsolete("Not Tested")]
        public Point Intersection(Line ln1, Line ln2, IntersectionPointCondition condition)
        {
            Vector p = new Vector(ln1.From);
            Vector r = new Vector(ln1.To - ln1.From);
            Vector q = new Vector(ln2.From);
            Vector s = new Vector(ln2.To - ln2.From);

            double numerator1 = Vector.CrossProduct(q - p, s);
            double numerator2 = Vector.CrossProduct(q - p, r);
            double denominator = Vector.CrossProduct(r, s);

            if (base._IsZero(denominator)) // parallel
            {
                return Point.Unset;
            }
            double t = numerator1 / denominator;
            double u = numerator2 / denominator;

            if (_IsZero(t))
            {
                t = 0;
            }
            else if (_IsSame(t, 1))
            {
                t = 1;
            }

            if (_IsZero(u))
            {
                u = 0;
            }
            else if (_IsSame(u, 1))
            {
                u = 1;
            }

            Point pt = new Point();
            switch (condition)
            {
                case IntersectionPointCondition.BothPointsInclude:
                    if (0 <= t && t <= 1 && 0 <= u && u <= 1)
                        pt = new Point(p + t * r);
                    break;
                case IntersectionPointCondition.OnlyStartPointInclude:
                    if (0 <= t && t < 1 && 0 <= u && u < 1)
                        pt = new Point(p + t * r);
                    break;
                case IntersectionPointCondition.OnlyEndPointInclude:
                    if (0 < t && t <= 1 && 0 < u && u <= 1)
                        pt = new Point(p + t * r);
                    break;
                case IntersectionPointCondition.BothPointExclude:
                    if (0 < t && t < 1 && 0 < u && u < 1)
                        pt = new Point(p + t * r);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return pt;
        }
    }
}
