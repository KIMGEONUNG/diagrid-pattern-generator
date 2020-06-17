using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeo.Primitive
{
    public struct Polygon
    {
        private ReadOnlyCollection<Point> pts;

        public int Count => pts.Count;
        public List<Point> Points => new List<Point>(pts);

        public Polygon(IEnumerable<Point> pts)
        {
            this.pts = new ReadOnlyCollection<Point>(pts.ToList());
        }


    }
}
