using AutomatedTellerMachine.Bills;
using AutomatedTellerMachine.Commands;
using AutomatedTellerMachine.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomatedTellerMachine.CashMachine
{
    /// <summary>
    /// An Automated Teller Machine.
    /// </summary>
    public class Teller : ITeller
    {
        /// <summary>
        /// Currency for bills in teller machine.
        /// </summary>
        public CurrencyBase Currency { get; set; }

        /// <summary>
        /// Current inventory of teller machine.
        /// </summary>
        private ICollection<BillBase> Bills { get; set; }

        /// <summary>
        /// Type and default quantities of bills to be stored in the teller machine.
        /// </summary>
        private Dictionary<Type, int> Register { get; set; }

        /// <summary>
        /// Create a new teller machine.
        /// </summary>
        public Teller()
        {
            // Defaulting to US Dollar.
            Currency = Activator.CreateInstance<Dollar>();

            // Initialize stock of bills.
            Bills = new List<BillBase>();

            Register = new Dictionary<Type, int>();

            AddBillToRegister<Hundred>();
            AddBillToRegister<Fifty>();
            AddBillToRegister<Twenty>();
            AddBillToRegister<Ten>();
            AddBillToRegister<Five>();
            AddBillToRegister<One>();
        }

        #region "Utility methods"

        /// <summary>
        /// Add a new type of bill to the register.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AddBillToRegister<T>() where T : BillBase
        {
            if (!Register.ContainsKey(typeof(T)))
            {
                Register.Add(typeof(T), ((BillBase)Activator.CreateInstance(typeof(T))).NormalStockLevel);

                Restock(typeof(T));
            }
        }

        /// <summary>
        /// Determine whether the register has a place for bills of the specified denomination.
        /// </summary>
        /// <param name="code">Code for the denomination.</param>
        /// <returns><c>Boolean</c> value specifcying whether denomination has a place in the register.</returns>
        public bool RegisterContainsDenomination(string code)
        {
            return Register.Keys.Any(item => ((BillBase)Activator.CreateInstance(item)).Code == code);
        }

        #endregion

        #region "Command actions"

        /// <summary>
        /// Restock a particular bill type in the teller machine.
        /// </summary>
        /// <param name="type">Bill type to be restocked.</param>
        private void Restock(Type type)
        {
            if (!Register.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException("Teller does not contain " + Convert.ToString(type) + " bills.");
            }

            int billCount = 0;
            int billsNeeded = 0;

            billCount = Bills.Where(bill => bill.GetType() == type).Count();

            billsNeeded = Register[type] - billCount;

            if (billsNeeded > 0)
            {
                for (int i = 0; i < billsNeeded; i++)
                {
                    Bills.Add(((BillBase)Activator.CreateInstance(type)));
                }
            }
        }

        /// <summary>
        /// Restock all bill types in the register.
        /// </summary>
        /// <returns>Inventory after restocking.</returns>
        public Response Restock()
        {
            foreach (Type type in Register.Keys)
            {
                Restock(type);
            }
            
            return FullInventory();
        }

        /// <summary>
        /// Get a full inventory of bills in the teller machine.
        /// </summary>
        /// <returns>Response message for user containing full inventory.</returns>
        public Response FullInventory()
        {
            List<string> denominations = new List<string>();

            foreach (Type type in Register.Keys)
            {
                denominations.Add(((BillBase)Activator.CreateInstance(type)).Code);
            }

            return Inventory(denominations);
        }

        /// <summary>
        /// Get an inventory of specified bill types in the teller machine.
        /// </summary>
        /// <param name="denominations">List of denominations to get an inventory of.</param>
        /// <returns>Response message for user containing an inventory.</returns>
        public Response Inventory(IList<string> denominations)
        {
            Response response = new Response();

            foreach (string denomination in denominations)
            {
                if (!RegisterContainsDenomination(denomination))
                {
                    throw new CommandException();
                }

                denomination.Trim();

                int count = Bills.Where(bill => bill.Code == denomination).Count();

                response.Message += "\n";
                response.Message += denomination + " - " + Convert.ToString(count);
                response.Message += "\n";
            }

            return response;
        }

        /// <summary>
        /// Withdraw an amount of money from the register.
        /// </summary>
        /// <param name="amount">Amount of money to be withdrawn.</param>
        /// <returns>Response message for display to user.</returns>
        public Response Withdraw(int amount)
        {
            Response response = new Response();

            if (amount > 0)
            {
                // amount = 100 * (amount / 100) + 50 * (amount / 50) + 20 * (amount / 20) + 10 * (amount / 10) + 5 * (amount / 5) + 1 * (amount / 1)

                List<BillBase> sieve = Bills.OrderByDescending(item => item.Value).ToList();
                
                if (sieve.Count == 0)
                {
                    response.Message += "\n";
                    response.Message += "Failure: Insufficient Funds";
                    response.Message += "\n";
                    return response;
                }

                int remainingAmount = amount;

                List<BillBase> withdraw = new List<BillBase>();

                while (remainingAmount != 0)
                {
                    BillBase biggestBill = sieve.FirstOrDefault();

                    if (biggestBill != null)
                    {
                        if (remainingAmount - biggestBill.Value < 0)
                        {
                            sieve.RemoveAll(item => item.Code == biggestBill.Code);
                        }
                        else
                        {
                            withdraw.Add(biggestBill);
                            sieve.Remove(biggestBill);

                            remainingAmount -= biggestBill.Value;
                        }
                    }
                    else
                    {
                        response.Message += "\n";
                        response.Message += "Failure: Insufficient Funds";
                        response.Message += "\n";
                        return response;
                    }
                }

                if (remainingAmount == 0)
                {
                    response.Message += "\n";
                    response.Message += "Success: Dispensed $" + Convert.ToString(amount);
                    response.Message += "\n";

                    foreach (BillBase bill in withdraw)
                    {
                        Bills.Remove(bill);
                    }

                    response.Message += FullInventory().Message;
                }
            }

            return response;
        }

        #endregion
    }
}
