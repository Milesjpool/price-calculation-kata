using NSubstitute;
using NUnit.Framework;
using PriceCalculator.Catalogue.Purchaseables;

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
        
        [Test]
        public void It_returns_a_held_item()
        {
            var purchaseable = Substitute.For<IPurchaseable>();
            
            var unit = new Basket();
            unit.Put(purchaseable);

            Assert.That(unit.TakeItem(), Is.EqualTo(purchaseable));
        }
        
        [Test]
        public void It_returns_multiple_held_items()
        {
            var purchaseable1 = Substitute.For<IPurchaseable>();
            var purchaseable2 = Substitute.For<IPurchaseable>();
            
            var unit = new Basket();
            unit.Put(purchaseable1);
            unit.Put(purchaseable2);

            Assert.That(unit.TakeItem(), Is.EqualTo(purchaseable2));
            Assert.That(unit.TakeItem(), Is.EqualTo(purchaseable1));
        }
        
        [Test]
        public void It_returns_nothing_when_empty()
        {
            var unit = new Basket();

            Assert.That(unit.TakeItem(), Is.Null);
        }
    }
}
