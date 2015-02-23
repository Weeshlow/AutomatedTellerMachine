using AutomatedTellerMachine.Currencies;
using System;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// The American one-dollar bill.
    /// </summary>
    public class One : BillBase
    {
        /// <summary>
        /// Create a new one-dollar bill.
        /// </summary>
        public One() 
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
                return 1;
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
