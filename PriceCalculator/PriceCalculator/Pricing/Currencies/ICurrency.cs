namespace PriceCalculator.Pricing.Currencies
{
    internal interface ICurrency
    {
        decimal FromPence(int pence);
    }
}