
namespace AutomatedTellerMachine.Commands
{
    /// <summary>
    /// Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <returns>Response message for the user.</returns>
        Response Execute();
    }
}
