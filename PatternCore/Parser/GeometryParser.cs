using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern.Core.Extension;
using Pattern.Core.System;

namespace Pattern.Core.Parser
{
    public class GeometryParser
    {
        #region Field

        private int xUnit;
        private int yUnit;
        #endregion

        #region Constructor

        public GeometryParser()
        {
            xUnit = 1;
            yUnit = 1;
        }

        public GeometryParser(int unit)
        {
            xUnit = unit;
            yUnit = unit;
        }

        public GeometryParser(int _xUnit, int _yUnit)
        {
            xUnit = _xUnit;
            yUnit = _yUnit;
        }
        #endregion

        #region Method

        public List<List<(int, int)>> ToPolygonPointList(System.DiagridSystem.RectangleFrameDiagrid grid)
        {
            var pls1 = grid.DiagridUnits.Select(n => ToPolygonPointList(n));
            var pls2 = grid.TriangleUnits.Select(n => ToPolygonPointList(n));

            return pls1.Concat(pls2).ToList();
        }

        public List<List<(int, int)>> ToPolygonPointList(Tessellation.QuadGrid grid)
        {
            var rs = new List<List<(int,int)>>();
            List<(int, int, int)> ls = grid.All3DCell();
            foreach ((int, int, int) i in ls)
            {
                var pl = QuadGridCellToPolygonPointList(i.Item1, i.Item2, (Direction)i.Item3);
                rs.Add(pl);
            }

            return rs;
        }

        public List<List<(int, int)>> ToPolygonPointList(System.SquareGridSystem.SquareGrid grid)
        {
            var pls = new List<List<(int, int)>>();
            int unit = 1;

            for (int i = 0; i < grid.YCount; i++)
            {
                for (int j = 0; j < grid.XCount; j++)
                {
                    var pt1 = new ValueTuple<int,int>(j, i);
                    var pt2 = new ValueTuple<int,int>(j + unit, i);
                    var pt3 = new ValueTuple<int,int>(j + unit, i + unit);
                    var pt4 = new ValueTuple<int,int>(j, i + unit);
                    pls.Add(new List<(int,int)>() { pt1, pt2, pt3, pt4});
                }
            }
            return pls;
        }

        public List<(int, int)> ToPolygonPointList(System.DiagridSystem.DiagridUnit u)
        {
            List<(int, int, int)> a = u.GetCells();

            var pts = u.GetCells()
                .Select(n => QuadGridCellToPolygonPointList(n.Item1, n.Item2, (Direction)n.Item3))
                .SelectMany(n => n);

            var xOrders = pts.OrderBy(n => n.Item1);
            var yOrders = pts.OrderBy(n => n.Item2);

            var pt1 = xOrders.Last();
            var pt2 = yOrders.Last();
            var pt3 = xOrders.First();
            var pt4 = yOrders.First();

            return new List<(int, int)> { pt1, pt2, pt3, pt4 };
        }

        public List<(int, int)> ToPolygonPointList(System.DiagridSystem.TriangleUnit unit)
        {
            (int,int) pt1 = new ValueTuple<int,int>();
            (int,int) pt2 = new ValueTuple<int, int>();
            (int,int) pt3 = new ValueTuple<int, int>();

            var pts = unit.GetCells()
                .Select(n => QuadGridCellToPolygonPointList(n.Item1, n.Item2, (Direction)n.Item3))
                .SelectMany(n => n);

            if (unit.Direction == Direction.Up || unit.Direction == Direction.Down)
            {
                var yOrdered = pts.OrderBy(n => n.Item2);
                var xOrdered = pts.OrderBy(n => n.Item1);
                pt1 = yOrdered.First();
                pt2 = yOrdered.Last();
                pt3 = unit.Direction == Direction.Up
                    ? xOrdered.First()
                    : unit.Direction == Direction.Down
                    ? xOrdered.Last()
                    : throw new NotImplementedException();
            }
            else if (unit.Direction == Direction.Left || unit.Direction == Direction.Right)
            {
                var yOrdered = pts.OrderBy(n => n.Item2);
                var xOrdered = pts.OrderBy(n => n.Item1);
                pt1 = xOrdered.First();
                pt2 = xOrdered.Last();
                pt3 = unit.Direction == Direction.Left
                ? yOrdered.First()
                : unit.Direction == Direction.Right
                ? yOrdered.Last()
                : throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            return new List<(int,int)> { pt1, pt2, pt3};
        }

        public List<(int, int)> ToPolygonPointList(System.SquareGridSystem.SquareUnit unit)
        {
            int mag = unit.Magification;
            var pt1 = new ValueTuple<int, int>(unit.X, unit.Y);
            var pt2 = new ValueTuple<int, int>(unit.X + mag, unit.Y);
            var pt3 = new ValueTuple<int, int>(unit.X + mag, unit.Y + mag);
            var pt4 = new ValueTuple<int, int>(unit.X, unit.Y + mag);

            var pts = new List<(int, int)> { pt1, pt2, pt3, pt4 };
            var rs = pts.Select(n => n.Multiply(xUnit,yUnit));
            return rs.ToList();
        }

        public List<(int, int)> QuadGridCellToPolygonPointList(int x, int y, Direction dir)
        {
            int halfxUnit = xUnit / 2;
            int halfyUnit = yUnit / 2;
            (int, int) basePt = new ValueTuple<int, int>(x * xUnit, y * yUnit).Add(halfxUnit, halfyUnit);
            (int, int) start = new ValueTuple<int, int>(x * xUnit, y * yUnit);
            (int, int) pt1 = new ValueTuple<int, int>();
            (int, int) pt2 = new ValueTuple<int, int>();
            switch (dir)
            {
                case Direction.Down:
                    pt1 = start.Add(0, 0);
                    pt2 = start.Add(xUnit, 0);
                    break;
                case Direction.Right:
                    pt1 = start.Add(xUnit, 0);
                    pt2 = start.Add(xUnit, yUnit);
                    break;
                case Direction.Up:
                    pt1 = start.Add(xUnit, yUnit);
                    pt2 = start.Add(0, yUnit);
                    break;
                case Direction.Left:
                    pt1 = start.Add(0, yUnit);
                    pt2 = start.Add(0, 0);
                    break;
                default:
                    break;
            }

            return new List<(int, int)> { basePt, pt1, pt2 };
        }
        #endregion
    }
}
