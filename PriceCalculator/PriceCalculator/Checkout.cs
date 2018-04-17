namespace PriceCalculator
{
    public class Checkout
    {
        public Price Total { get; private set; }

        public Checkout()
        {
            Total = new Price();
        }

        public void Scan(Basket basket)
        {
        }
    }
}