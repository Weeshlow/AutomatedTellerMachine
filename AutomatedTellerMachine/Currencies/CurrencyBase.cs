
namespace AutomatedTellerMachine.Currencies
{
    /// <summary>
    /// Currency.
    /// </summary>
    public abstract class CurrencyBase
    {
        /// <summary>
        /// Character code for this currency.
        /// </summary>
        public abstract char Code { get; }
    }
}
