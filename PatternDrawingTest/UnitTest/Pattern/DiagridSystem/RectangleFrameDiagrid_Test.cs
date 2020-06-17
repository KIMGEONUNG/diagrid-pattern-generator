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
    public class RectangleFrameDiagrid_Test
    {
        [TestMethod]
        public void ConstructorTest()
        {
            RectangleFrameDiagrid quadGrid = new RectangleFrameDiagrid(10, 10);
            Assert.IsTrue(quadGrid.XCount == 10);
            Assert.IsTrue(quadGrid.YCount == 10);
            Assert.IsTrue(quadGrid.ZCount == 4);
        }
    }
}
