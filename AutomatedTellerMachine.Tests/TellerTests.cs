using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomatedTellerMachine.CashMachine;
using AutomatedTellerMachine.Commands;

namespace AutomatedTellerMachine.Tests
{
    [TestClass]
    public class TellerTests
    {
        [TestMethod]
        public void TellerHasNormalStockLevels()
        {
            Response expected = new Response();
            expected.Message += "\n";
            expected.Message += "$100 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$50 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$20 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$10 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$5 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$1 - 10";
            expected.Message += "\n";

            Teller teller = new Teller();

            Response actual = teller.Restock();

            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TellerDispensesOnce()
        {
            Response expected = new Response();
            expected.Message += "\n";
            expected.Message += "Success: Dispensed $208";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$100 - 8";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$50 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$20 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$10 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$5 - 9";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$1 - 7";
            expected.Message += "\n";

            Teller teller = new Teller();

            Response actual = teller.Withdraw(208);

            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TellerDispensesTwice()
        {
            Response expected = new Response();
            expected.Message += "\n";
            expected.Message += "Success: Dispensed $9";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$100 - 8";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$50 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$20 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$10 - 10";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$5 - 8";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$1 - 3";
            expected.Message += "\n";

            Teller teller = new Teller();

            Response actual = teller.Withdraw(208);
            actual = teller.Withdraw(9);

            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TellerRunsOutOfOnes()
        {
            Response expected = new Response();
            expected.Message += "\n";
            expected.Message += "Failure: Insufficient Funds";
            expected.Message += "\n";

            Teller teller = new Teller();

            Response actual = teller.Withdraw(208);
            actual = teller.Withdraw(9);
            actual = teller.Withdraw(9);

            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TellerCanBeEmptied()
        {
            Response expected = new Response();
            expected.Message += "\n";
            expected.Message += "Success: Dispensed $1860";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$100 - 0";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$50 - 0";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$20 - 0";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$10 - 0";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$5 - 0";
            expected.Message += "\n";
            expected.Message += "\n";
            expected.Message += "$1 - 0";
            expected.Message += "\n";

            Teller teller = new Teller();

            Response actual = teller.Withdraw(1860);

            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}
