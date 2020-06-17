using Newtonsoft.Json;
using Pattern.Core.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.DiagridSystem
{
    [DebuggerDisplay("X : {X} , Y : {Y} , Mag : {Magnification}")]
    public struct DiagridUnit
    {
        [JsonProperty]
        public int X { get; private set; }
        [JsonProperty]
        public int Y { get; private set; }
        [JsonProperty]
        public int Magnification { get; private set; }

        public DiagridUnit(int x, int y, int mag)
        {
            X = x;
            Y = y;
            Magnification = mag;
        }

        public List<(int,int,int)> GetCells()
        {
            var rs = new List<(int, int, int)>();
            // Start XY Cell과 증가 방향을 정한다.
            var startUpXY = new ValueTuple<int, int>(X, Y);
            var startDownXY = new ValueTuple<int, int>(X, Y-1);
            var incrementalW = new ValueTuple<int, int>(1, 0);
            var incrementalUpH = new ValueTuple<int, int>(0, 1);
            var incrementalDownH = new ValueTuple<int, int>(0, -1);
            dynamic upZs = new { left = new int[] { 1, 2, }, right = new int[] { 1, 4 }, sole = 1 };
            dynamic downZs = new { left = new int[] { 2, 3, }, right = new int[] { 3, 4 }, sole = 3 };

            // Calculate Interval을 정한다.
            var calculateInterval = new List<(int, int)>();
            var bottomLine = Enumerable.Range(0, Magnification).ToList();
            while (bottomLine.Count != 0)
            {
                calculateInterval.Add(new ValueTuple<int, int>(bottomLine.First(), bottomLine.Last()));

                if (bottomLine.Count == 1)
                {
                    bottomLine.RemoveAt(0);
                }
                else
                {
                    bottomLine.RemoveAt(0);
                    bottomLine.RemoveAt(bottomLine.Count - 1);
                }
            }

            foreach ((int, int) interval in calculateInterval)
            {
                if (interval.Item1 == interval.Item2)
                {
                    var targetUpXY = startUpXY.Add(incrementalW.Multiply(interval.Item2));
                    var targetDownXY = startDownXY.Add(incrementalW.Multiply(interval.Item2));
                    rs.Add(new ValueTuple<int, int, int>(targetUpXY.Item1, targetUpXY.Item2, upZs.sole));
                    rs.Add(new ValueTuple<int, int, int>(targetDownXY.Item1, targetDownXY.Item2, downZs.sole));
                    continue;
                }

                for (int i = interval.Item1; i <= interval.Item2; i++)
                {
                    var targetUpXY = startUpXY.Add(incrementalW.Multiply(i));
                    var targetDownXY = startDownXY.Add(incrementalW.Multiply(i));
                    int[] targetUpZs = null;
                    int[] targetDownZs = null;
                    if (i == interval.Item1)
                    {
                        targetUpZs = upZs.left;
                        targetDownZs = downZs.left;
                    }
                    else if (i == interval.Item2)
                    {
                        targetUpZs = upZs.right;
                        targetDownZs = downZs.right;
                    }
                    else
                    {
                        targetUpZs = new int[] { 1, 2, 3, 4 };
                        targetDownZs = new int[] { 1, 2, 3, 4 };
                    }

                    foreach (int item in targetUpZs)
                    {
                        rs.Add(new ValueTuple<int, int, int>(targetUpXY.Item1, targetUpXY.Item2, item));
                    }
                    foreach (int item in targetDownZs)
                    {
                        rs.Add(new ValueTuple<int, int, int>(targetDownXY.Item1, targetDownXY.Item2, item));
                    }
                }
                startUpXY = startUpXY.Add(incrementalUpH);
                startDownXY = startDownXY.Add(incrementalDownH);
            }
            return rs;
        }
    }
}
