using AutomatedTellerMachine.CashMachine;

namespace AutomatedTellerMachine.Commands
{
    /// <summary>
    /// Restock command for teller machine.
    /// </summary>
    public class Restock : ICommand
    {
        private ITeller _teller { get; set; }

        /// <summary>
        /// Create a new restock command.
        /// </summary>
        /// <param name="teller">Teller machine to execute the command.</param>
        public Restock(ITeller teller)
        {
            _teller = teller;
        }

        /// <summary>
        /// Execute the restock command.
        /// </summary>
        /// <returns>Response message for user.</returns>
        public Response Execute()
        {
            return _teller.Restock();
        }
    }
}
