using ComarGeo.Core;
using ComarGeo.Primitive;
using ComarGeo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComarGeoTest.Core
{
    [TestClass]
    public class GeoHandler_Test
    {
        [TestMethod]
        public void IsPointOnLine_Test1()
        {
            var handler = new GeoHandler();
            var ln = new Line(0, 0, 10, 0);
            var pt1 = new Point(-10, 0);
            var pt2 = new Point(0, 0);
            var pt3 = new Point(5, 0);
            var pt4 = new Point(10, 0);
            var pt5 = new Point(15, 0);

            Assert.IsFalse(handler.IsPointOnLine(pt1, ln));
            Assert.IsTrue(handler.IsPointOnLine(pt2, ln));
            Assert.IsTrue(handler.IsPointOnLine(pt3, ln));
            Assert.IsTrue(handler.IsPointOnLine(pt4, ln));
            Assert.IsFalse(handler.IsPointOnLine(pt5, ln));
        }

        [TestMethod]
        public void IsPointOnLine_Test2()
        {
            var handler = new GeoHandler();
            var ln = new Line(0, 0, 2, 1);
            var pt1 = new Point(1, 0.5);
            var pt2 = new Point(1, 0.5 + 0.000000000001);
            Assert.IsTrue(handler.IsPointOnLine(pt1, ln));
            Assert.IsTrue(handler.IsPointOnLine(pt2, ln));
        }

        [TestMethod]
        public void LineBasedPointPosition_Test1()
        {
            var handler = new GeoHandler();
            var ln = new Line(0, 0, 10, 10);
            var pt1 = new Point(10, 10);
            var pt2 = new Point(0, 0);
            var pt3 = new Point(20, 20);
            var pt4 = new Point(100, 5);
            var pt5 = new Point(-20, 5);

            Assert.IsTrue(handler.LineBasedPointPosition(pt1, ln) == PointPositionWithLine.OnTheLineOrHorizonal);
            Assert.IsTrue(handler.LineBasedPointPosition(pt2, ln) == PointPositionWithLine.OnTheLineOrHorizonal);
            Assert.IsTrue(handler.LineBasedPointPosition(pt3, ln) == PointPositionWithLine.OutOfBoundary);
            Assert.IsTrue(handler.LineBasedPointPosition(pt4, ln) == PointPositionWithLine.Right);
            Assert.IsTrue(handler.LineBasedPointPosition(pt5, ln) == PointPositionWithLine.Left);
        }

        [TestMethod]
        public void LineBasedPointPosition_Test2()
        {
            var handler = new GeoHandler();
            var ln = new Line(0, 0, 10, 0);
            var pt1 = new Point(5, 5);
            var pt2 = new Point(20, 0);

            Assert.IsTrue(handler.LineBasedPointPosition(pt1, ln) == PointPositionWithLine.OutOfBoundary);
            Assert.IsTrue(handler.LineBasedPointPosition(pt2, ln) == PointPositionWithLine.OnTheLineOrHorizonal);
        }

        [TestMethod]
        public void PointInPolygon_Test1()
        {
            var handler = new GeoHandler();

            var pts = new List<Point>()
            {
                new Point(0,0),
                new Point(2,3),
                new Point(-2,7),
            };
            var poly = new Polygon(pts);
            var pt1 = new Point(1, 1);
            var pt2 = new Point(0, 1);
            var pt3 = new Point(1.50921, 2.2638);

            Assert.IsTrue(handler.PointInPolygon(pt1, poly) == PointPositionWithPolygon.Outside);
            Assert.IsTrue(handler.PointInPolygon(pt2, poly) == PointPositionWithPolygon.Inside);
            Assert.IsTrue(handler.PointInPolygon(pt3, poly) == PointPositionWithPolygon.OnBoundary);
        }
    }
}
