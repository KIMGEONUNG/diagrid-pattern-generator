using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.Tessellation
{
    /// <summary>
    /// 사각형 그리드의 각 cell들이 두 개의 대각선으로 나누어진 형태의 그리드
    /// </summary>
    public class QuadGrid : RegularGrid3D
    {
        
        #region Property
        public override List<(int, int, int)> All3DCell()
        {
            var rs = new List<(int, int, int)>();
            for (int z = 1; z <= ZCount; z++)
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

        #region Constructor

        public QuadGrid(int _xCount, int _yCount)
        {
            this.XCount = _xCount;
            this.YCount = _yCount;
            this.ZCount = 4;
        }
        #endregion

        #region Method

        #endregion
    }
}
