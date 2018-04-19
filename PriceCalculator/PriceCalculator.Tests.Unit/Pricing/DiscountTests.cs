using NUnit.Framework;
using PriceCalculator.Pricing;

namespace PriceCalculator.Tests.Unit.Pricing
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        public void It_has_a_value()
        {
            var unit = new Discount(50);
            Assert.That(unit.InPounds(), Is.EqualTo(-0.5));
        }  
        
        [Test]
        public void It_can_add_another_discount()
        {
            var unit = new Discount(50);
            var other = new Discount(30);
            Assert.That(unit.Add(other).InPounds(), Is.EqualTo(-0.8));
        }
    }
}