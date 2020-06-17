using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern.Core.Tessellation;

namespace Pattern.Core.System.SquareGridSystem
{
    /// <summary>
    /// Unit을 채울 수 있는 대상
    /// </summary>
    public class SquareGrid : RegularGrid2D 
    {
        #region Field

        private List<SquareUnit> units = new List<SquareUnit>();
        #endregion

        #region Property

        public List<SquareUnit> AllUnits => units.ToList();
        #endregion

        #region Constructor

        public SquareGrid(int _xCount, int _yCount)
        {
            this.XCount = _xCount;
            this.YCount = _yCount;
        }
        #endregion

        #region Method

        public List<(int, int)> GetVoidCellList()
        {
            List<(int, int)> all = this.All2DCell();
            List<(int, int)> subtracts = units.SelectMany(n => n.GetCells()).ToList();

            var rs = all.Except(subtracts).ToList();

            return rs;
        }

        public bool Insert(SquareUnit unit)
        {
            if (!IsInsertValid(this, unit))
            {
                return false;
            }
            units.Add(unit);
            return true;
        }

        private static bool IsInsertValid(SquareGrid grid, SquareUnit unit)
        {
            List<(int, int)> existCells = grid.units.SelectMany(n => n.GetCells()).ToList();
            List<(int, int)> newCells = unit.GetCells();

            // 중첩 존재
            var intersect = existCells.Intersect(newCells);
            if (intersect.Count() != 0)
            {
                return false;
            }

            // 범위 초과
            if (unit.GetCells().Exists(n => grid.XCount <= n.Item1) 
                || unit.GetCells().Exists(n => grid.YCount <= n.Item2))
            {
                return false;   
            }

            return true;
        }
        #endregion
    }
}
