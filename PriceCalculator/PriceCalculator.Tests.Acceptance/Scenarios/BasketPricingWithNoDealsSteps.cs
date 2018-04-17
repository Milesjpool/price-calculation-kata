using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricingWithNoDeals
    {
        private Basket _basket;
        private Price _total;
        private Checkout _checkout;

        [SetUp]
        public void BeforeEach()
        {
            _basket = new Basket();
            _checkout = new Checkout(new ShopCatalogue());           
        }

        private void GivenTheBasketHasBread()
        {
            _basket.Put(new Bread());
        }
        
        private void GivenTheBasketHasButter()
        {
            _basket.Put(new Butter());
        }
        private void GivenTheBasketHasMilk()
        {
            _basket.Put(new Milk());
        }

        private void WhenITotalTheBasket()
        {
            _checkout.Scan(_basket);
            _total = _checkout.Total;
        }

        private void ThenTheTotalShouldBe(double expectedTotal)
        {
            Assert.That(_total.InPounds(), Is.EqualTo(expectedTotal));
        }

        private BasketPricingWithNoDeals And { get { return this; } }
    }
}
