using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCoreTestProject.UnitTest.Utility
{
    [TestClass]
    public class Pixel_Test
    {
        [TestMethod]
        public void BasicTest()
        {
            int x = 10;
            int y = 10;
            byte val = 25;

            var pixel = new Pixel(x, y, val, 10,10);
            Assert.IsTrue(pixel.X == 10);
            Assert.IsTrue(pixel.Y == 10);
            Assert.IsTrue(pixel.Val == 25);
            Assert.IsTrue(pixel.PixelCenterX == 10);
            Assert.IsTrue(pixel.PixelCenterY == 10);
        }
    }
}
