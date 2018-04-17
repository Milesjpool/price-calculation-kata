using NSubstitute;
using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Unit
{
    [TestFixture]
    class CheckoutTests
    {
        private readonly ICatalogue _itemCatalogue = Substitute.For<ICatalogue>();
        private readonly IPurchaseable _item1 = Substitute.For<IPurchaseable>();
        private readonly IPurchaseable _item2 = Substitute.For<IPurchaseable>();
        private readonly IScannable _basket = Substitute.For<IScannable>();
        private readonly Price _item1Price = new Price(10);
        private readonly Price _item2Price = new Price(20);

        [Test]
        public void The_total_is_initially_zero()
        {
            var unit = new Checkout(_itemCatalogue);
            Assert.That(unit.Total.InPounds(), Is.EqualTo(0));
        }
        
        [Test]
        public void The_total_can_be_the_price_of_multiple_scanned_items()
        {
            var unit = new Checkout(_itemCatalogue);
            _basket.TakeItem().Returns(_item1, _item2, null);
            _itemCatalogue.LookupPrice(_item1).Returns(_item1Price);
            _itemCatalogue.LookupPrice(_item2).Returns(_item2Price);

            unit.Scan(_basket);

            var expected = _item1Price.InPounds() + _item2Price.InPounds();
            Assert.That(unit.Total.InPounds(), Is.EqualTo(expected));
        }
    }
}
