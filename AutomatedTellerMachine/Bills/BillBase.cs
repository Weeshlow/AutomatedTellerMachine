using AutomatedTellerMachine.Currencies;
using System;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// Entity base for physical denominations of cash.
    /// </summary>
    public abstract class BillBase
    {
        /// <summary>
        /// Currency for the bill.
        /// </summary>
        public CurrencyBase Currency { get; set; }

        /// <summary>
        /// Create a new bill.
        /// </summary>
        /// <param name="currency">Currency for the new bill.</param>
        public BillBase(CurrencyBase currency)
        {
            Currency = currency;
        }

        /// <summary>
        /// Code name for a physical denomination of cash.
        /// </summary>
        public string Code
        {
            get
            {
                return Currency.Code + Convert.ToString(Value);
            }
        }
        
        /// <summary>
        /// Units of value for the bill in the specified currency.
        /// </summary>
        public virtual int Value { get; set; }

        /// <summary>
        /// Normal stock level for the bill.
        /// </summary>
        public virtual int NormalStockLevel { get; set; }
    }
}
