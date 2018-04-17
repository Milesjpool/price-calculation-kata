using NSubstitute;
using NUnit.Framework;

namespace PriceCalculator.Tests.Unit
{
    [TestFixture]
    class BasketTests
    {
        [Test]
        public void It_takes_a_purchaseable_item()
        {
            var purchaseable = Substitute.For<IPurchaseable>();
            
            var unit = new Basket();

            Assert.DoesNotThrow(() => unit.Put(purchaseable));
        }
    }
}
