using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UBalance.Library.Classes;
namespace UBalance.Tests
{
    [TestClass]
    public class UBalanceTesting
    {
        [TestMethod]
        public void NoParenthesis()
        {
            Calculation c = new Calculation("2+3+5");

            Assert.AreEqual(10.0, c.ReEval());
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
        public void ColorTest()
        {
            ColorReader c = new ColorReader("COM3", "X");

            //Assert(true);
        }
    }
}
