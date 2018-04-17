using NUnit.Framework;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricing
    {
        [Test]
        public void No_deals_applicable()
        {
            GivenTheBasketHasBreadButterAndMilk();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(2.95);
        }
    }
}