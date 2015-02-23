using AutomatedTellerMachine.CashMachine;
using AutomatedTellerMachine.Commands;
using System;

namespace AutomatedTellerMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Instantiate a teller
                ITeller teller = new Teller();

                // Instantiate a command processor.
                Invoker invoker = new Invoker(teller);

                // Command shell
                while (true)
                {
                    try
                    {
                        // Get command input, with no prompt.
                        string input = Console.ReadLine();

                        // Process user input.
                        invoker.SetCommand(invoker.ParseCommand(input));

                        // Get response for user.
                        Response response = invoker.Invoke();

                        // Display teller response to user.
                        Console.WriteLine(response.Message);
                    }
                    catch (CommandException ex)
                    {
                        // Display error message for unprocessed or unrecognized commands.
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch
                    {
                        // No other error messages.
                    }
                }
            }
            catch
            {
                // No other error messages.
            }
        }       
    }
}
