namespace PriceCalculator.Pricing
{
    public class Discount : IPriceIncrement
    {
        private static readonly ICurrency Currency = new Gbp();

        public int NetPence { get; private set; }

        public Discount(int pence)
        {
            NetPence = -pence;
        }

        public decimal InPounds()
        {
            return Currency.FromPence(NetPence);
        }

        public Discount Add(Discount other)
        {
            var totalDiscount = NetPence + other.NetPence;
            return new Discount(-totalDiscount);
        }
    }
}