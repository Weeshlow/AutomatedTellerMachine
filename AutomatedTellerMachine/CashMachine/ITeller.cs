using AutomatedTellerMachine.Commands;
using AutomatedTellerMachine.Currencies;
using System.Collections.Generic;

namespace AutomatedTellerMachine.CashMachine
{
    public interface ITeller
    {
        /// <summary>
        /// Currency in use for this teller machine.
        /// </summary>
        CurrencyBase Currency { get; }

        /// <summary>
        /// Withdraw an amount of money from the teller machine.
        /// </summary>
        /// <param name="amount">Amount of money to withdraw.</param>
        /// <returns>Response message for user.</returns>
        Response Withdraw(int amount);

        /// <summary>
        /// Get an inventory of specified denominations.
        /// </summary>
        /// <param name="denominations">List of denominations.</param>
        /// <returns>Response message for user.</returns>
        Response Inventory(IList<string> denominations);

        /// <summary>
        /// Restock the teller machine.
        /// </summary>
        /// <returns>Response message for user.</returns>
        Response Restock();

        /// <summary>
        /// Add a register slot for a type of bill.
        /// </summary>
        /// <typeparam name="T">Type of bill to be used in register slot.</typeparam>
        void AddBillToRegister<T>() where T : Bills.BillBase;
    }
}
