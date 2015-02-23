using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTellerMachine.Currencies;

namespace AutomatedTellerMachine.Bills
{
    /// <summary>
    /// The American hundred-dollar bill.
    /// </summary>
    public class Hundred : BillBase
    {
        /// <summary>
        /// Create a new hundred-dollar bill.
        /// </summary>
        public Hundred() 
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
                return 100;
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
