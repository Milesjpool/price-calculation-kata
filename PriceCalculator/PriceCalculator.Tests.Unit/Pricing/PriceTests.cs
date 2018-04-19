using NUnit.Framework;
using PriceCalculator.Pricing;

namespace PriceCalculator.Tests.Unit.Pricing
{
    [TestFixture]
    class PriceTests
    {
        [Test]
        public void It_can_be_read_in_pounds_and_pence()
        {
            var unit = new Price(159);
            Assert.That(unit.InPounds(), Is.EqualTo(1.59));
        }
        
        [Test] 
        public void It_is_initially_zero()
        {
            var unit = new Price();
            Assert.That(unit.InPounds(), Is.EqualTo(0));
        }
        
        [Test]
        public void It_can_add_another_Price()
        {
            var unit = new Price(100);
            var other = new Price(200);
            var expectedPrice = unit.InPounds() + other.InPounds();
            
            var actualPrice = unit.Add(other);
            
            Assert.That(actualPrice.InPounds(), Is.EqualTo(expectedPrice));
        }
        
        [Test]
        public void It_can_add_a_discount()
        {
            var unit = new Price(100);
            var discount = new Discount(50);
            var expectedPrice = unit.InPounds() + discount.InPounds();
            
            var actualPrice = unit.Add(discount);
            
            Assert.That(actualPrice.InPounds(), Is.EqualTo(expectedPrice));
        }
    }
}
