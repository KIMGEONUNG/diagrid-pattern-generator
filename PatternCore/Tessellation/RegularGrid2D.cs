using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Tessellation
{
    /// <summary>
    ///  Data structure for regular 2d grid
    /// 규칙적인 2d grid 자료구조 
    /// </summary>
    public class RegularGrid2D
    {
        public int XCount { get; set; }
        public int YCount { get; set; }

        public virtual List<(int, int)> All2DCell()
        {
            var rs = new List<(int, int)>();
            for (int i = 0; i < YCount; i++)
            {
                for (int j = 0; j < XCount; j++)
                {
                    rs.Add(new ValueTuple<int, int>(j, i));
                }
            }

            return rs;
        }
    }
}
