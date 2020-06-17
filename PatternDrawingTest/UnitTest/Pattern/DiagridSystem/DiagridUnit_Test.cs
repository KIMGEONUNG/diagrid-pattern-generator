using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.System.DiagridSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDrawingTestProject.UnitTest.Pattern.DiagridSystem
{
    [TestClass]
    public class DiagridUnit_Test
    {
        [TestMethod]
        public void CellLogicTest()
        {
            var dia1Mag1 = new DiagridUnit(0, 1, 1);
            List<(int, int, int)> cells1Mag1 = dia1Mag1.GetCells();
            Assert.IsTrue(cells1Mag1.Count == 2);
            Assert.IsTrue(cells1Mag1.Contains(new ValueTuple<int, int, int>(0, 0, 3)));
            Assert.IsTrue(cells1Mag1.Contains(new ValueTuple<int, int, int>(0, 1, 1)));

            var dia1Mag2 = new DiagridUnit(0,1,2);
            List<(int, int, int)> cells1Mag2 = dia1Mag2.GetCells();
            Assert.IsTrue(cells1Mag2.Count == 8);
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(0, 1, 1)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(0, 1, 2)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(0, 0, 3)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(0, 0, 2)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 1, 4)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 1, 1)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 0, 4)));
            Assert.IsTrue(cells1Mag2.Contains(new ValueTuple<int, int, int>(1, 0, 3)));

            var dia1Mag3 = new DiagridUnit(0, 1, 3);
            List<(int, int, int)> cells1Mag3 = dia1Mag3.GetCells();
            Assert.IsTrue(cells1Mag3.Count == 18);
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 1, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 1, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 0, 3)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(0, 0, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 1, 4)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 1, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 4)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 3)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 2, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 1, 3)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 1, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 2)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, 0, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(1, -1, 3)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 1, 4)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 1, 1)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 0, 4)));
            Assert.IsTrue(cells1Mag3.Contains(new ValueTuple<int, int, int>(2, 0, 3)));

        }
    }
}
