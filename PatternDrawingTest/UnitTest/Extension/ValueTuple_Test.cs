using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pattern.Core.Extension;

namespace PatternDrawingTestProject.UnitTest.Extension
{
    [TestClass]
    public class ValueTuple_Test
    {
        [TestMethod]
        public void ArithmeticOperationTest1()
        {
            var add1 = new ValueTuple<int, int>(1, 2);
            var add2 = new ValueTuple<int, int>(2, 3);
            var add3 = add1.Add(add2);
            var mul = add3.Multiply(3);
            Assert.IsTrue(add3.Equals(new ValueTuple<int, int>(3, 5)));
            Assert.IsTrue(mul.Equals(new ValueTuple<int, int>(9, 15)));
        }

        [TestMethod]
        public void ArithmeticOperationTest2()
        {
            var add1 = new ValueTuple<int, int>(1, 2);
            var add2 = add1.Add(2,3);
            Assert.IsTrue(add2.Equals(new ValueTuple<int, int>(3, 5)));
        }
    }
}
