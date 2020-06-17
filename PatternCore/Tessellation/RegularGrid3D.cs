using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Tessellation
{
    public class RegularGrid3D : RegularGrid2D
    {
        #region Property
        public int ZCount { get; set; }
        #endregion

        #region Method

        public virtual List<(int, int, int)> All3DCell()
        {
            var rs = new List<(int, int, int)>();
            for (int z = 0; z < ZCount; z++)
            {
                for (int y = 0; y < YCount; y++)
                {
                    for (int x = 0; x < XCount; x++)
                    {
                        rs.Add(new ValueTuple<int, int, int>(x, y, z));
                    }
                }
            }

            return rs;
        }
        #endregion
    }
}
