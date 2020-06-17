using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.SquareGridSystem
{
    /// <summary>
    /// 패턴의 최소 단위
    /// </summary>
    public class SquareUnit
    {
        #region Field

        private int x;
        private int y;
        private int magnification;
        #endregion

        #region Property

        public int X => x;
        public int Y => y;
        public int Magification => magnification;
        #endregion

        #region Constructor

        public SquareUnit(int _x, int _y, int _magnification)
        {
            this.x = _x;
            this.y = _y;
            this.magnification = _magnification; 
        }
        #endregion

        #region Method

        public List<(int, int)> GetCells()
        {
            var rs = new List<(int, int)>();

            for (int i = 0; i < magnification; i++)
            {
                for (int j = 0; j < magnification; j++)
                {
                    rs.Add(new ValueTuple<int,int>(x + j, y + i));
                }
            }

            return rs;
        }
        #endregion
    }
}
