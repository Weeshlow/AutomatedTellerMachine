using AutomatedTellerMachine.Currencies;
using System;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// The American five-dollar bill.
    /// </summary>
    public class Five : BillBase
    {
        /// <summary>
        /// Create a new five-dollar bill.
        /// </summary>
        public Five() 
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
                return 5;
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
