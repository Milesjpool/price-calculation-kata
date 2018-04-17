using NUnit.Framework;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricingWithNoDeals
    {
        [Test]
        public void Bread_Butter_and_Milk()
        {
            GivenTheBasketHasBread();
            And.GivenTheBasketHasButter();
            And.GivenTheBasketHasMilk();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(2.95);
        }
        
        [Test]
        public void Two_Bread_Two_Milk_and_a_Butter()
        {
            GivenTheBasketHasBread();
            And.GivenTheBasketHasBread();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasButter();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(5.10);
        }
    }
}