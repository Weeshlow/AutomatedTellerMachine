using AutomatedTellerMachine.Currencies;
using System;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// The American ten-dollar bill.
    /// </summary>
    public class Ten : BillBase
    {
        /// <summary>
        /// Create a new ten-dollar bill.
        /// </summary>
        public Ten() 
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
                return 10;
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
