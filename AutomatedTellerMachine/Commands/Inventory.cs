using AutomatedTellerMachine.CashMachine;
using System.Collections.Generic;

namespace AutomatedTellerMachine.Commands
{
    /// <summary>
    /// Inventory command.
    /// </summary>
    public class Inventory : ICommand
    {
        private ITeller _teller { get; set; }
        private IList<string> _denominations { get; set; }

        /// <summary>
        /// Create a new inventory command.
        /// </summary>
        /// <param name="teller">Teller machine to execute the inventory command.</param>
        /// <param name="args">Arguments for the inventory command.</param>
        public Inventory(ITeller teller, IList<string> args)
        {
            _teller = teller;
            _denominations = args;
        }

        /// <summary>
        /// Execute the inventory command.
        /// </summary>
        /// <returns>Response message for user.</returns>
        public Response Execute()
        {
            return _teller.Inventory(_denominations);
        }
    }
}
