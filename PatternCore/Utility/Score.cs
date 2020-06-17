using ComarGeo.Core;
using ComarGeo.Primitive;
using Pattern.Core.Parser;
using Pattern.Core.System.DiagridSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComarGeo.Model;

namespace Pattern.Core.Utility
{
    public class Score
    {
        /// <summary>
        /// 큰 diagridUnit에 pixel이 들어갈 수록 높은 점수를 받는다.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="intension"></param>
        public double EstimateInclusionScore(RectangleFrameDiagrid grid, IntensionLayer intension, GeometryParser parser)
        {
            var handler = new GeoHandler();
            List<List<(int, int)>> all = parser.ToPolygonPointList(grid);
            double width = all.SelectMany(n => n).Max(n => n.Item1);
            double height = all.SelectMany(n => n).Max(n => n.Item2);
            List<Pixel> pixels = intension.GetPixels(width,height);

            var diagridUnits = grid.DiagridUnits;

            var inspections = diagridUnits
                .Select(n => new { pointList = parser.ToPolygonPointList(n), mag = n.Magnification })
                .Select(n => new { pts = n.pointList.Select(k => new Point(k.Item1, k.Item2)), mag = n.mag })
                .Select(n => new { polygon = new Polygon(n.pts), mag = n.mag })
                .ToList();
                

            double total = 0;
            foreach (var inspect in inspections)
            {
                var inclusions = pixels
                    .Where(n => handler.PointInPolygon(new Point(n.PixelCenterX, n.PixelCenterY), inspect.polygon) == PointPositionWithPolygon.Inside)
                    .ToList();

                double score = inclusions
                    .Select(n => (int)n.Val)
                    .Sum();

                double weightedScore = score * inspect.mag;
                total += weightedScore;
            }

            return total;
        }

    }
}
