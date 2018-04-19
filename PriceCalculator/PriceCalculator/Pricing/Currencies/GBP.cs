namespace PriceCalculator.Pricing.Currencies
{
    public class Gbp : ICurrency
    {
        private const int PenceInPound = 100;     

        public decimal FromPence(int pence)
        {
            return (decimal) pence / PenceInPound;
        }
    }
}