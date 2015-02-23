
namespace AutomatedTellerMachine.Currencies
{
    /// <summary>
    /// American (US) Dollar currency.
    /// </summary>
    public class Dollar : CurrencyBase
    {
        /// <summary>
        /// Code for a currency.
        /// </summary>
        public override char Code
        {
            get
            {
                return '$';
            }
        }
    }
}
