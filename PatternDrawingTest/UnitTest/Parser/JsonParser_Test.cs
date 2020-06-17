using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pattern.Core.Parser;
using Pattern.Core.System.DiagridSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PatternCoreTestProject.UnitTest.Parser
{
    [TestClass]
    public class JsonParser_Test
    {
        [TestMethod]
        public void ToJson_Test1()
        {
            var parser = new JsonParser();
            var unit = new DiagridUnit(4, 4, 2);
            string json = parser.ToJson(unit);

            DiagridUnit de = JsonConvert.DeserializeObject<DiagridUnit>(json);

            Assert.IsTrue(unit.Equals(de));
        }

        [TestMethod]
        public void ToJson_Test2()
        {
            var parser = new JsonParser();
            var diaUnit = new DiagridUnit(6, 6, 2);
            var triUnit = new TriangleUnit(0, 0, 2, Pattern.Core.System.Direction.Right);

            var quad = new RectangleFrameDiagrid(20, 20);
            quad.Insert(diaUnit);
            quad.Insert(triUnit);

            string json = JsonConvert.SerializeObject(quad);

            RectangleFrameDiagrid de = JsonConvert.DeserializeObject<RectangleFrameDiagrid>(json);

        }

    }
}
