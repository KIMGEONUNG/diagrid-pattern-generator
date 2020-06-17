using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.DiagridSystem
{
    public class DiagridPacker
    {
        public void Pack(ref RectangleFrameDiagrid grid, int triangleMinUnit, int triangleMaxUnit, (int,int)[] magIters)
        {
            int min = triangleMinUnit;
            int max = triangleMaxUnit;
            int xLimit = grid.XCount;
            int yLimit = grid.YCount;

            #region Packing Triangle

            var r1 = new Random();

            // Right
            int go1 = 0;
            while (true)
            {
                int remain = xLimit - go1;
                if (remain <= max)
                {
                    grid.Insert(new TriangleUnit(go1, 0, remain, Direction.Right));
                    break;
                }
                int ran = r1.Next(min, max);
                grid.Insert(new TriangleUnit(go1, 0, ran, Direction.Right));
                go1 += ran;
            }

            // Up
            int go2 = 0;
            while (true)
            {
                int remain = yLimit - go2;
                if (remain <= max)
                {
                    grid.Insert(new TriangleUnit(xLimit, go2, remain, Direction.Up));
                    break;
                }
                int ran = r1.Next(min, max);
                grid.Insert(new TriangleUnit(xLimit, go2, ran, Direction.Up));
                go2 += ran;
            }

            // Left
            int go3 = 0;
            while (true)
            {
                int remain = xLimit - go3;
                if (remain <= max)
                {
                    grid.Insert(new TriangleUnit(xLimit - go3, yLimit, remain, Direction.Left));
                    break;
                }
                int ran = r1.Next(min, max);
                grid.Insert(new TriangleUnit(xLimit - go3, yLimit, ran, Direction.Left));
                go3 += ran;
            }

            // Down
            int go4 = 0;
            while (true)
            {
                int remain = yLimit - go4;
                if (remain <= max)
                {
                    grid.Insert(new TriangleUnit(0, yLimit - go4, remain, Direction.Down));
                    break;
                }
                int ran = r1.Next(min, max);
                grid.Insert(new TriangleUnit(0, yLimit - go4, ran, Direction.Down));
                go4 += ran;
            }
            #endregion

            var r2 = new Random();

            var mags = new int[] { 9, 5, 4, 3, 2 };
            var iters = new int[] { 2, 6, 16, 40, 60 };
            foreach (var magIter in magIters)
            {
                int mag =magIter.Item1;
                int iter = magIter.Item2;
                for (int j = 0; j < iter; j++)
                {
                    int escape = 0;
                    while (true)
                    {
                        escape++;
                        int x = r2.Next(grid.XCount);
                        int y = r2.Next(grid.YCount);
                        DiagridUnit ug = new DiagridUnit(x, y, mag);
                        if (grid.Insert(ug))
                        {
                            break;
                        }
                        if (100 < escape)
                        {
                            break;
                        }
                    }
                }

            }
            foreach (var item in grid.GetVoidCellList())
            {
                int x = item.Item1;
                int y = item.Item2;
                int z = item.Item3;

                switch (z)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        y += 1;
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }

                grid.Insert(new DiagridUnit(x, y, 1));
            }

        }
    }
}
