namespace PriceCalculator.Pricing
{
    public class Price : IPriceIncrement
    {
        private static readonly ICurrency Currency = new Gbp();

        public int NetPence { get; private set; }

        public Price():this(0)
        {
        }

        public Price(int pence)
        {
            NetPence = pence;
        }

        public decimal InPounds()
        {
            return Currency.FromPence(NetPence);
        }

        public Price Add(IPriceIncrement other)
        {
            return new Price(NetPence + other.NetPence);
        }
    }
}