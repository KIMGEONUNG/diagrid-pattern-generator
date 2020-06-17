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
    /// <summary>
    /// Test image 
    /// 
    /// </summary>
    /// <remarks>
    /// Magnification example
    /// <img src="\media\triangle_unit_magnification_diagram.jpg"/>
    /// </remarks>
    [DebuggerDisplay("X : {X} , Y : {Y} , Mag : {Magnification} , Dir : {Direction}")]
    public struct TriangleUnit
    {
        /// <summary>
        /// X coordinates
        /// </summary>
        [JsonProperty]
        public int X { get; private set; }
        /// <summary>
        /// Y coordinates
        /// </summary>
        [JsonProperty]
        public int Y { get; private set; }
        /// <summary>
        /// the size of triangle unit
        /// </summary>
        [JsonProperty]
        public int Magnification { get; private set; }
        /// <summary>
        /// direction of triangle unit
        /// </summary>
        [JsonProperty]
        public Direction Direction { get; private set; }

        public TriangleUnit(int x, int y, int mag, Direction dir)
        {
            X = x;
            Y = y;
            Magnification = mag;
            Direction = dir;
        }

        public List<(int, int, int)> GetCells()
        {
            var rs = new List<(int, int, int)>();
            // Start XY Cell과 증가 방향을 정한다.
            ValueTuple<int, int> startXY = new ValueTuple<int, int>();
            ValueTuple<int, int> incrementalW = new ValueTuple<int, int>();
            ValueTuple<int, int> incrementalH = new ValueTuple<int, int>();
            dynamic zs = null;
            switch (Direction)
            {
                case Direction.Down:
                    startXY = new ValueTuple<int, int>(X, Y-1);
                    incrementalW = new ValueTuple<int, int>(0, -1);
                    incrementalH = new ValueTuple<int, int>(1, 0);
                    zs = new { left = new int[] { 1, 4, }, right = new int[] { 3, 4 }, down = 4 };
                    break;
                case Direction.Right:
                    startXY = new ValueTuple<int, int>(X, Y);
                    incrementalW = new ValueTuple<int, int>(1, 0);
                    incrementalH = new ValueTuple<int, int>(0, 1);
                    zs = new { left = new int[] { 1, 2, }, right = new int[] { 1, 4 }, down = 1 };
                    break;
                case Direction.Up:
                    startXY = new ValueTuple<int, int>(X-1, Y);
                    incrementalW = new ValueTuple<int, int>(0, 1);
                    incrementalH = new ValueTuple<int, int>(-1, 0);
                    zs = new { left = new int[] { 2, 3, }, right = new int[] { 1, 2 }, down = 2 };
                    break;
                case Direction.Left:
                    startXY = new ValueTuple<int, int>(X-1, Y-1);
                    incrementalW = new ValueTuple<int, int>(-1, 0);
                    incrementalH = new ValueTuple<int, int>(0, -1);
                    zs = new { left = new int[] { 3, 4, }, right = new int[] { 2, 3 }, down = 3 };
                    break;
                default:
                    throw new NotImplementedException();
            }

            // 사용되는 모든 XY Cell을 정한다.
            // Calculate Interval을 정한다.
            var calculateInterval = new List<(int, int)>();
            var bottomLine = Enumerable.Range(0, Magnification).ToList();
            while (bottomLine.Count != 0)
            {
                calculateInterval.Add(new ValueTuple<int,int>(bottomLine.First(), bottomLine.Last()));

                if (bottomLine.Count == 1)
                {
                    bottomLine.RemoveAt(0);
                }
                else
                {
                    bottomLine.RemoveAt(0);
                    bottomLine.RemoveAt(bottomLine.Count -1);
                }
            }

            foreach ((int, int) interval in calculateInterval)
            {
                if (interval.Item1 == interval.Item2)
                {
                    var targetXY = startXY.Add(incrementalW.Multiply(interval.Item2));
                    rs.Add(new ValueTuple<int, int, int>(targetXY.Item1, targetXY.Item2, zs.down));
                    continue;
                }

                for (int i = interval.Item1; i <= interval.Item2; i++)
                {
                    var targetXY = startXY.Add(incrementalW.Multiply(i));
                    int[] targetZs = null;
                    if (i == interval.Item1)
                    {
                        targetZs = zs.left;
                    }
                    else if (i == interval.Item2)
                    {
                        targetZs = zs.right;
                    }
                    else
                    {
                        targetZs = new int[] { 1, 2, 3, 4 };
                    }

                    foreach (int item in targetZs)
                    {
                        rs.Add(new ValueTuple<int, int, int>(targetXY.Item1, targetXY.Item2, item));
                    }
                }
                startXY = startXY.Add(incrementalH);
            }
            return rs;
        }
    }
}
