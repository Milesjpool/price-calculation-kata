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
            GivenTheBasketHasBread(2);
            And.GivenTheBasketHasMilk(2);
            And.GivenTheBasketHasButter();
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(5.10);
        }

        [Test]
        public void Half_price_bread_with_bread_and_two_butter()
        {
            GivenTheBasketHasButter(2);
            And.GivenTheBasketHasBread(2);
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(3.10);
        } 
        
        [Test]
        public void Free_milk_with_four_milks()
        {
            GivenTheBasketHasMilk(4);
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(3.45);
        }
        
        [Test]
        public void Two_free_milks_and_half_price_bread()
        {
            GivenTheBasketHasMilk(8);
            And.GivenTheBasketHasBread();
            And.GivenTheBasketHasButter(2);
            WhenITotalTheBasket();
            ThenTheTotalShouldBe(9);
        }
    }
}