namespace PriceCalculator.Pricing
{
    internal interface ICurrency
    {
        decimal FromPence(int pence);
    }
}