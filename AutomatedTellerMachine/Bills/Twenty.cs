using AutomatedTellerMachine.Currencies;
using System;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// The American twenty-dollar bill.
    /// </summary>
    public class Twenty : BillBase
    {
        /// <summary>
        /// Create a new twenty-dollar bill.
        /// </summary>
        public Twenty()
            : base(Activator.CreateInstance<Dollar>())
        {

        }

        /// <summary>
        /// Units of value for the bill in the specified currency.
        /// </summary>
        public override int Value
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Normal stock level for the bill.
        /// </summary>
        public override int NormalStockLevel
        {
            get
            {
                return 10;
            }
        }
    }
}
