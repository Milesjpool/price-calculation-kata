using System.Collections.ObjectModel;
using NSubstitute;
using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Tests.Unit
{
    [TestFixture]
    class CheckoutTests
    {
        private readonly IPurchaseable _item1 = Substitute.For<IPurchaseable>();
        private readonly Price _item1Price = new Price(10);
        private readonly IPurchaseable _item2 = Substitute.For<IPurchaseable>();
        private readonly Price _item2Price = new Price(20);
        private readonly Discount _discountValue = new Discount(5);

        private readonly IScannable _basket = Substitute.For<IScannable>();
        private readonly ICatalogue _itemCatalogue = Substitute.For<ICatalogue>();
        private readonly IDiscounts _discounts = Substitute.For<IDiscounts>();

        [Test]
        public void The_total_is_initially_zero()
        {
            var unit = new Checkout(_itemCatalogue, _discounts);
            _discounts.GetApplicable(Arg.Any<Collection<IPurchaseable>>()).Returns(new Discount(0));            

            Assert.That(unit.GetTotal().AsCurrency(), Is.EqualTo(0));
        }
        
        [Test]
        public void The_total_is_the_total_price_of_multiple_scanned_items()
        {
            var unit = new Checkout(_itemCatalogue, _discounts);
            _basket.TakeItem().Returns(_item1, _item2, null);
            _itemCatalogue.LookupPrice(_item1).Returns(_item1Price);
            _itemCatalogue.LookupPrice(_item2).Returns(_item2Price);
            _discounts.GetApplicable(Arg.Any<Collection<IPurchaseable>>()).Returns(new Discount(0));            

            unit.Scan(_basket);

            var expected = _item1Price.AsCurrency() + _item2Price.AsCurrency();
            Assert.That(unit.GetTotal().AsCurrency(), Is.EqualTo(expected));
        }
        
        [Test]
        public void The_total_is_the_total_price_minus_discounts()
        {
            var unit = new Checkout(_itemCatalogue, _discounts);
            _basket.TakeItem().Returns(_item1, null, null);
            _itemCatalogue.LookupPrice(_item1).Returns(_item1Price);
            _discounts.GetApplicable(Arg.Any<Collection<IPurchaseable>>()).Returns(_discountValue);

            unit.Scan(_basket);

            var expected = _item1Price.AsCurrency() + _discountValue.InCurrency();
            Assert.That(unit.GetTotal().AsCurrency(), Is.EqualTo(expected));
        }

        [Test]
        public void Test_name()
        {
            Assert.That(new Collection<IPurchaseable>{_item1}, Is.EqualTo(new Collection<IPurchaseable>{_item1}));
        }
    }
}
