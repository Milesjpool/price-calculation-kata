using NUnit.Framework;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricing
    {
        private Basket _basket;
        private Price _total;

        private void GivenTheBasketHasBreadButterAndMilk()
        {
            _basket = new Basket();
            _basket.Put(new Bread());
            _basket.Put(new Butter());
            _basket.Put(new Milk());
        }

        private void WhenITotalTheBasket()
        {
            var checkout = new Checkout();
            checkout.Scan(_basket);
            _total = checkout.Total;
        }

        private void ThenTheTotalShouldBe(double expectedTotal)
        {
            Assert.That(_total.InPounds(), Is.EqualTo(expectedTotal));
        }
    }
}
