using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Primitive
{
    public struct Polyline
    {
        ReadOnlyCollection<Point> pts;

        public Polyline(IEnumerable<Point> pts)
        {
            this.pts = new ReadOnlyCollection<Point>(pts.ToList());
        }

    }
}
