using System;

namespace AutomatedTellerMachine.Commands
{
    public class CommandException : Exception
    {
        public CommandException() : base ("Failure: Invalid Command")
        {

        }

        public CommandException(string message) : base (message)
        {

        }

        public CommandException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
