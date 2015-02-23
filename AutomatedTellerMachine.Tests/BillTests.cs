using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.Bills;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class BillTests
    {
        [TestMethod]
        public void HundredCodeTest()
        {
            Hundred hundred = new Hundred();

            Assert.AreEqual(hundred.Code, "$100");
        }

        [TestMethod]
        public void FiftyCodeTest()
        {
            Fifty fifty = new Fifty();

            Assert.AreEqual(fifty.Code, "$50");
        }

        [TestMethod]
        public void TwentyCodeTest()
        {
            Twenty twenty = new Twenty();

            Assert.AreEqual(twenty.Code, "$20");
        }

        [TestMethod]
        public void TenCodeTest()
        {
            Ten ten = new Ten();

            Assert.AreEqual(ten.Code, "$10");
        }

        [TestMethod]
        public void FiveCodeTest()
        {
            Five five = new Five();

            Assert.AreEqual(five.Code, "$5");
        }

        [TestMethod]
        public void OneCodeTest()
        {
            One one = new One();

            Assert.AreEqual(one.Code, "$1");
        }
    }
}
