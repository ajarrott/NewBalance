using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewBalance.Library.Classes;
namespace NewBalance.Tests
{
    [TestClass]
    public class NewBalanceTesting
    {
        [TestMethod]
        public void NoParenthesis()
        {
            Calculation c = new Calculation("2+3+5");

            Assert.AreEqual(10.0, c.ReEval());
        }

        [TestMethod]
        public void Twoparenthesis()
        {
            Calculation c = new Calculation("(3+2)/(3+2)");

            Assert.AreEqual((3.0+2.0)/(3.0+2.0), c.ReEval());
        }

        [TestMethod]
        public void Parenthesis()
        {
            Calculation c = new Calculation("(2+3)*5");

            Assert.AreEqual(25.0, c.ReEval());
        }

        [TestMethod]
        public void LargerEq()
        {
            Calculation c = new Calculation("2^3*(1+2+3)/10+3.14159");

            Assert.AreEqual(Math.Pow(2, 3) * (1 + 2 + 3) / 10 + 3.14159, c.ReEval());
        }

        [TestMethod]
        public void MultipleParenthesis()
        {
            Calculation c = new Calculation("((1-2)/(2-4))*10");
            Assert.AreEqual(expected: ((1.0 - 2.0)/(2.0 - 4.0)) * 10.0, actual: c.ReEval());
        }

        [TestMethod]
        public void ColorTest()
        {
            ColorReader c = new ColorReader("COM3", "X");

            //Assert(true);
        }
    }
}
