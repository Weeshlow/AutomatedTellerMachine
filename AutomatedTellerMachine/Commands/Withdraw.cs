using AutomatedTellerMachine.CashMachine;

namespace AutomatedTellerMachine.Commands
{
    /// <summary>
    /// Command to withdraw funds from a teller machine.
    /// </summary>
    public class Withdraw : ICommand
    {
        /// <summary>
        /// Teller machine that will be withdrawn from.
        /// </summary>
        private ITeller _teller { get; set; }

        /// <summary>
        /// Amount of money to be withdrawn.
        /// </summary>
        private int _amount { get; set; }

        /// <summary>
        /// Withdraw the specified amount of money from the specified teller machine.
        /// </summary>
        /// <param name="teller">Teller machine to withdraw money from.</param>
        /// <param name="amount">Amount of money to be withdrawn.</param>
        public Withdraw(ITeller teller, int amount)
        {
            _teller = teller;
            _amount = amount;
        }

        /// <summary>
        /// Ask the teller to execute the command.
        /// </summary>
        /// <returns>Response message for user.</returns>
        public Response Execute()
        {
            return _teller.Withdraw(_amount);
        }
    }
}
