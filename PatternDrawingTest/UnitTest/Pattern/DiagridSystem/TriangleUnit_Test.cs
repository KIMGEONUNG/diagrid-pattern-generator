using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.System.DiagridSystem;
using Pattern.Core.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDrawingTestProject.UnitTest.Pattern.DiagridSystem
{
    [TestClass]
    public class TriangleUnit_Test
    {
        [TestMethod]
        public void CellLogicTest()
        {
            #region Mag1

            var triangle1Mag1 = new TriangleUnit(1, 1, 1, Direction.Right);
            var triangle2Mag1 = new TriangleUnit(1, 1, 1, Direction.Up);
            var triangle3Mag1 = new TriangleUnit(1, 1, 1, Direction.Left);
            var triangle4Mag1 = new TriangleUnit(1, 1, 1, Direction.Down);
            Assert.IsTrue(triangle1Mag1.GetCells().Single().Equals(new ValueTuple<int, int, int>(1, 1, 1)));
            Assert.IsTrue(triangle2Mag1.GetCells().Single().Equals(new ValueTuple<int, int, int>(0, 1, 2)));
            Assert.IsTrue(triangle3Mag1.GetCells().Single().Equals(new ValueTuple<int, int, int>(0, 0, 3)));
            Assert.IsTrue(triangle4Mag1.GetCells().Single().Equals(new ValueTuple<int, int, int>(1, 0, 4)));
            #endregion

            #region Mag2

            var triangle1Mag2 = new TriangleUnit(1, 1, 2, Direction.Right);
            List<(int, int, int)> cells1Mag2 = triangle1Mag2.GetCells();
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 1, 1)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 1, 2)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(2, 1, 4)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(2, 1, 1)));

            var triangle2Mag2 = new TriangleUnit(1, 1, 2, Direction.Up);
            List<(int, int, int)> cells2Mag2 = triangle2Mag2.GetCells();
            Assert.IsTrue(cells2Mag2.Contains(new ValueTuple<int, int, int>(0, 1, 2)));
            Assert.IsTrue(cells2Mag2.Contains(new ValueTuple<int, int, int>(0, 1, 3)));
            Assert.IsTrue(cells2Mag2.Contains(new ValueTuple<int, int, int>(0, 2, 1)));
            Assert.IsTrue(cells2Mag2.Contains(new ValueTuple<int, int, int>(0, 2, 2)));

            var triangle3Mag2 = new TriangleUnit(1, 1, 2, Direction.Left);
            List<(int, int, int)> cells3Mag2 = triangle3Mag2.GetCells();
            Assert.IsTrue(cells3Mag2.Contains(new ValueTuple<int, int, int>(0, 0, 3)));
            Assert.IsTrue(cells3Mag2.Contains(new ValueTuple<int, int, int>(0, 0, 4)));
            Assert.IsTrue(cells3Mag2.Contains(new ValueTuple<int, int, int>(-1, 0, 3)));
            Assert.IsTrue(cells3Mag2.Contains(new ValueTuple<int, int, int>(-1, 0, 2)));

            var triangle4Mag2 = new TriangleUnit(1, 1, 2, Direction.Down);
            List<(int, int, int)> cells4Mag2 = triangle4Mag2.GetCells();
            Assert.IsTrue(cells4Mag2.Contains(new ValueTuple<int, int, int>(1, 0, 4)));
            Assert.IsTrue(cells4Mag2.Contains(new ValueTuple<int, int, int>(1, 0, 1)));
            Assert.IsTrue(cells4Mag2.Contains(new ValueTuple<int, int, int>(1, -1, 3)));
            Assert.IsTrue(cells4Mag2.Contains(new ValueTuple<int, int, int>(1, -1, 4)));
            #endregion

            #region Mag3

            var triangle1Mag3 = new TriangleUnit(0, 0, 3, Direction.Right);
            List<(int, int, int)> cells1Mag3 = triangle1Mag3.GetCells();
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 0, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 0, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 0, 4)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 0, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 1, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 3)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 4)));
            #endregion

        }
    }
}
