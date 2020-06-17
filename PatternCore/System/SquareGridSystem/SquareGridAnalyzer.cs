using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.SquareGridSystem
{
    public class SquareGridAnalyzer
    {
        /// <summary>
        /// 그리드의 꺾인선의 수를 합한다.
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int CalculateSequenceInteruptCount(List<SquareUnit> units)
        {
            int count = 0;
            var xs = new HashSet<(int, int, int)>();
            var ys = new HashSet<(int, int, int)>();

            foreach (SquareUnit unit in units)
            {
                int x = unit.X;
                int y = unit.Y;
                int mag = unit.Magification;

                for (int i = 0; i < mag; i++)
                {
                    // Get All X
                    xs.Add(new ValueTuple<int,int,int>(y, x + i, x + 1 + i));
                    // Get All Y
                    ys.Add(new ValueTuple<int,int,int>(x, y + i, y + 1 + i));
                }
            }

            foreach (var hash in new HashSet<(int, int, int)>[] { xs, ys, })
            {
                IEnumerable<IGrouping<int, (int, int, int)>> hashGroups = hash.GroupBy(n => n.Item1);
                foreach (IGrouping<int, (int, int, int)> group in hashGroups)
                {
                    List<(int, int)> orderedSeq = group
                        .Select(n => new ValueTuple<int, int>(n.Item2, n.Item3))
                        .OrderBy(n => n.Item1)
                        .ToList();
                    for (int i = 1; i < orderedSeq.Count; i++)
                    {
                        (int, int) prior = orderedSeq[i - 1];
                        (int, int) post = orderedSeq[i];

                        if (prior.Item2 != post.Item1)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public int CalculateDistributedScore(List<SquareUnit> units)
        {
            double score = 0;
            Func<SquareUnit, SquareUnit, double> getDist =
                (u1, u2) => Math.Sqrt(Math.Pow(u1.X - u2.X, 2) + Math.Pow(u1.Y - u2.Y, 2));

            IEnumerable<IGrouping<int, SquareUnit>> unitGroup = units
                .Where(n => n.Magification != 1)
                .GroupBy(n => n.Magification);

            foreach (IGrouping<int, SquareUnit> group in unitGroup)
            {
                double sum = 0;
                foreach (SquareUnit el in group)
                {
                    double min = double.MaxValue;
                    foreach (var item in group.Where(n => n.X != el.X && n.Y != el.Y))
                    {
                        min = Math.Min(min, getDist(el, item));
                    }
                    sum += min;
                }
                double avg = sum / group.Count();
                score += avg * group.Key;
            }

            return (int)score;
        }
    }
}
