using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.SquareGridSystem
{
    /// <summary>
    /// Grid에 Unit을 채워 넣는다.
    /// </summary>
    public class Packer
    {
        /// <summary>
        /// 4 ,2, 1 mag의 유닛이 각각 1/3의 면적을 확보하도록 논리전개
        /// </summary>
        /// <param name="grid"></param>
        public void SimplePack1(ref SquareGrid grid)
        {
            var r = new Random();

            var mags = new int[] { 4, 3, 2 };
            int wholeArea = grid.XCount * grid.YCount;
            int evenDivedArea = wholeArea / (mags.Length + 1);
            var iters = mags.Select(n => (int)(evenDivedArea / Math.Pow(n, 2))).ToArray();
            for (int i = 0; i < mags.Length; i++)
            {
                int mag = mags[i];
                int iter = iters[i];
                for (int j = 0; j < iter; j++)
                {
                    while (true)
                    {
                        int x = r.Next(grid.XCount);
                        int y = r.Next(grid.YCount);
                        SquareUnit ug = new SquareUnit(x, y, mag);
                        if (grid.Insert(ug))
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
                if (!grid.Insert(new SquareUnit(x, y, 1)))
                {
                    throw new Exception();
                }
            }

        }
    }
}
