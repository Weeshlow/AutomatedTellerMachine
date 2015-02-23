using AutomatedTellerMachine.CashMachine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.Commands
{
    /// <summary>
    /// Command system for the Automated Teller Machine.
    /// </summary>
    public class Invoker
    {
        private ICommand _command;
        private ITeller _teller;

        /// <summary>
        /// Create a new invoker.
        /// </summary>
        /// <param name="teller">Teller machine that will execute commands.</param>
        public Invoker(ITeller teller)
        {
            _teller = teller;
        }

        /// <summary>
        /// Set the command to be invoked.
        /// </summary>
        /// <param name="command">Command to be invoked.</param>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        /// Invoke the set command.
        /// </summary>
        /// <returns>Response message for user.</returns>
        public Response Invoke()
        {
            if (_command == null)
            {
                throw new ArgumentException("Command not set for invoker.");
            }

            return _command.Execute();
        }

        /// <summary>
        ///  Parse an input string for a command.
        /// </summary>
        /// <param name="input">User input string.</param>
        /// <returns>Command created from user input string.</returns>
        public ICommand ParseCommand(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            // Commands are space delimited.
            IList<string> args = input.Split(' ').ToList();

            switch (args[0])
            {
                case "R":
                    // Restock the teller machine.
                    if (args.Count != 1)
                    {
                        throw new CommandException();
                    }

                    return new Restock(_teller);
                case "I":
                    // Get inventory levels for the teller machine.
                    args.RemoveAt(0);

                    if (args.Count == 0)
                    {
                        throw new CommandException();
                    }
                    
                    return new Inventory(_teller, args);
                case "W":
                    // Withdraw money from the teller machine.
                    args.RemoveAt(0);

                    if (args.Count != 1 || args[0][0] != _teller.Currency.Code)
                    {
                        throw new CommandException();
                    }

                    int amount = Convert.ToInt32(args[0].Remove(0,1));
                    
                    return new Withdraw(_teller, amount);
                case "Q":
                    // Quit the application.
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }

            // Unrecognized command
            throw new CommandException("Failure: Invalid Command");
        }
    }
}
