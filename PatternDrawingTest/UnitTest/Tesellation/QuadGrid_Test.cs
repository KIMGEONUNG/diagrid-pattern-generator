using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.Tessellation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDrawingTestProject.UnitTest.Tesellation
{
    [TestClass]
    public class QuadGrid_Test
    {
        [TestMethod]
        public void ConstructorTest()
        {
            QuadGrid quadGrid = new QuadGrid(10, 10);
            Assert.IsTrue(quadGrid.XCount == 10);
            Assert.IsTrue(quadGrid.YCount == 10);
            Assert.IsTrue(quadGrid.ZCount == 4);
        }
    }
}
