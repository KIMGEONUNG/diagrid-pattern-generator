using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.Extension;
using Pattern.Core.Parser;
using Pattern.Core.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCoreTestProject.UnitTest.Parser
{
    [TestClass]
    public class GeometryParser_Test
    {
        [TestMethod]
        public void QuadGridCellToPolygonPointListTest1()
        {
            var parser = new GeometryParser(2);
            List<(int, int)> pts = parser.QuadGridCellToPolygonPointList(2, 3, Direction.Down);

            Assert.IsTrue(pts.Contains((4,6)));
            Assert.IsTrue(pts.Contains((6,6)));
            Assert.IsTrue(pts.Contains((5,7)));
        }

        [TestMethod]
        public void QuadGridCellToPolygonPointListTest2()
        {
            var parser = new GeometryParser(2);
            List<(int, int)> pts = parser.QuadGridCellToPolygonPointList(2, 3, Direction.Right);

            Assert.IsTrue(pts.Contains((6, 6)));
            Assert.IsTrue(pts.Contains((6, 8)));
            Assert.IsTrue(pts.Contains((5, 7)));
        }

        [TestMethod]
        public void QuadGridCellToPolygonPointListTest3()
        {
            var parser = new GeometryParser(2);
            List<(int, int)> pts = parser.QuadGridCellToPolygonPointList(2, 3, Direction.Up);

            Assert.IsTrue(pts.Contains((6, 8)));
            Assert.IsTrue(pts.Contains((4, 8)));
            Assert.IsTrue(pts.Contains((5, 7)));
        }

        [TestMethod]
        public void QuadGridCellToPolygonPointListTest4()
        {
            var parser = new GeometryParser(2);
            List<(int, int)> pts = parser.QuadGridCellToPolygonPointList(2, 3, Direction.Left);

            Assert.IsTrue(pts.Contains((4, 6)));
            Assert.IsTrue(pts.Contains((4, 8)));
            Assert.IsTrue(pts.Contains((5, 7)));
        }

        [TestMethod]
        public void ToPolygonPointList_DiagridUnit_Test1()
        {
            var parser = new GeometryParser(2);
            var dia = new Pattern.Core.System.DiagridSystem.DiagridUnit(1,1,2);
            List<(int, int)> pts = parser.ToPolygonPointList(dia);

            Assert.IsTrue(pts.Contains((1, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((3, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((2, 2).Multiply(2)));
            Assert.IsTrue(pts.Contains((2, 0).Multiply(2)));
        }

        [TestMethod]
        public void ToPolygonPointList_TriangleUnit_Test1()
        {
            var parser = new GeometryParser(2);
            var tri = new Pattern.Core.System.DiagridSystem.TriangleUnit(1, 1, 2, Direction.Right);
            List<(int, int)> pts = parser.ToPolygonPointList(tri);

            Assert.IsTrue(pts.Contains((1, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((3, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((2, 2).Multiply(2)));
        }

        [TestMethod]
        public void ToPolygonPointList_TriangleUnit_Test2()
        {
            var parser = new GeometryParser(2);
            var tri = new Pattern.Core.System.DiagridSystem.TriangleUnit(1, 1, 2, Direction.Up);
            List<(int, int)> pts = parser.ToPolygonPointList(tri);

            Assert.IsTrue(pts.Contains((1, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((1, 3).Multiply(2)));
            Assert.IsTrue(pts.Contains((0, 2).Multiply(2)));
        }

        [TestMethod]
        public void ToPolygonPointList_TriangleUnit_Test3()
        {
            var parser = new GeometryParser(2);
            var tri = new Pattern.Core.System.DiagridSystem.TriangleUnit(1, 1, 2, Direction.Left);
            List<(int, int)> pts = parser.ToPolygonPointList(tri);

            Assert.IsTrue(pts.Contains((1, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((0, 0).Multiply(2)));
            Assert.IsTrue(pts.Contains((-1, 1).Multiply(2)));
        }

        [TestMethod]
        public void ToPolygonPointList_TriangleUnit_Test4()
        {
            var parser = new GeometryParser(2);
            var tri = new Pattern.Core.System.DiagridSystem.TriangleUnit(1, 1, 2, Direction.Down);
            List<(int, int)> pts = parser.ToPolygonPointList(tri);

            Assert.IsTrue(pts.Contains((1, 1).Multiply(2)));
            Assert.IsTrue(pts.Contains((2, 0).Multiply(2)));
            Assert.IsTrue(pts.Contains((1, -1).Multiply(2)));
        }

        [TestMethod]
        public void ToPolygonPointList_SquareUnit_Test1()
        {
            var parser = new GeometryParser(2);
            var tri = new Pattern.Core.System.SquareGridSystem.SquareUnit(1, 1, 2);
            List<(int, int)> pts = parser.ToPolygonPointList(tri);

            Assert.IsTrue(pts.Contains((2, 2)));
            Assert.IsTrue(pts.Contains((6, 2)));
            Assert.IsTrue(pts.Contains((6, 6)));
            Assert.IsTrue(pts.Contains((2, 6)));
        }
    }
}
