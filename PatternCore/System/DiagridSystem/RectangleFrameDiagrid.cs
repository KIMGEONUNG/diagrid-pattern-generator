using Newtonsoft.Json;
using Pattern.Core.Tessellation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Core.System.DiagridSystem
{
    /// <summary>
    /// 외곽선은 직사각형이면서 직사각형 내부는 Diagrid로 이루어진 Panel을 Rectangle Frame Diagird라고 한다.
    /// </summary>
    public class RectangleFrameDiagrid : QuadGrid
    {
        [JsonProperty]
        private List<DiagridUnit> driagridUnits = new List<DiagridUnit>();
        [JsonProperty]
        private List<TriangleUnit> triangleUnits = new List<TriangleUnit>();

        public RectangleFrameDiagrid(int _xCount, int _yCount):base(_xCount,_yCount)
        {

        }
        [JsonIgnore]
        public List<DiagridUnit> DiagridUnits { get => driagridUnits; }
        [JsonIgnore]
        public List<TriangleUnit> TriangleUnits { get => triangleUnits; }

        #region Method

        public List<(int, int, int)> GetVoidCellList()
        {
            List<(int, int,int)> all = this.All3DCell();
            List<(int, int, int)> subtracts = driagridUnits
                .SelectMany(n => n.GetCells())
                .Concat(triangleUnits.SelectMany(n => n.GetCells()))
                .ToList();

            var rs = all.Except(subtracts).ToList();

            return rs;
        }

        public bool Insert(TriangleUnit unit)
        {
            if (!IsInsertValid(this, unit))
            {
                return false;
            }
            triangleUnits.Add(unit);
            return true;
        }

        public bool Insert(DiagridUnit unit)
        {
            if (!IsInsertValid(this, unit))
            {
                return false;
            }
            driagridUnits.Add(unit);
            return true;
        }

        private static bool IsInsertValid(RectangleFrameDiagrid grid, DiagridUnit unit)
        {
            List<(int, int, int)> existCells1 = grid.DiagridUnits.SelectMany(n => n.GetCells()).ToList();
            List<(int, int, int)> existCells2 = grid.TriangleUnits.SelectMany(n => n.GetCells()).ToList();
            List<(int, int, int)> existCells = existCells1.Concat(existCells2).ToList();
            List<(int, int, int)> newCells = unit.GetCells();

            // 중첩 존재
            var intersect = existCells.Intersect(newCells);
            if (intersect.Count() != 0)
            {
                return false;
            }

            // 범위 초과
            if (unit.GetCells().Exists(n => grid.XCount <= n.Item1 || n.Item1 < 0)
                || unit.GetCells().Exists(n => grid.YCount <= n.Item2 || n.Item2 < 0))
            {
                return false;
            }

            return true;
        }

        private static bool IsInsertValid(RectangleFrameDiagrid grid, TriangleUnit unit)
        {
            List<(int, int, int)> existCells1 = grid.DiagridUnits.SelectMany(n => n.GetCells()).ToList();
            List<(int, int, int)> existCells2 = grid.TriangleUnits.SelectMany(n => n.GetCells()).ToList();
            List<(int, int, int)> existCells = existCells1.Concat(existCells2).ToList();
            List<(int, int, int)> newCells = unit.GetCells();

            // 중첩 존재
            var intersect = existCells.Intersect(newCells);
            if (intersect.Count() != 0)
            {
                return false;
            }

            // 범위 초과
            if (unit.GetCells().Exists(n => grid.XCount <= n.Item1 || n.Item1 < 0)
                || unit.GetCells().Exists(n => grid.YCount <= n.Item2 || n.Item2 < 0))
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
