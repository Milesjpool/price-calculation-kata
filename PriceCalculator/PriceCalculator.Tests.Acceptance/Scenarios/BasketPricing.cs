using NUnit.Framework;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricing
    {
        [Test]
        public void No_deals_with_bread_butter_and_milk()
        {
            GivenTheBasketHasBread();
            And.GivenTheBasketHasButter();
            And.GivenTheBasketHasMilk();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(2.95);
        }
        
        [Test]
        public void No_deals_with_two_bread_two_milk_and_butter()
        {
            GivenTheBasketHasBread();
            And.GivenTheBasketHasBread();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasButter();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(5.10);
        }

        [Test]
        public void Half_price_bread_with_bread_and_two_butter()
        {
            GivenTheBasketHasButter();
            And.GivenTheBasketHasButter();
            And.GivenTheBasketHasBread();
            And.GivenTheBasketHasBread();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(3.10);
        } 
        
        [Test]
        public void Free_milk_with_four_milks()
        {
            GivenTheBasketHasMilk();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasMilk();
            And.GivenTheBasketHasMilk();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(3.45);
        }
    }
}