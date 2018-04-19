using System.Collections.ObjectModel;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Deals;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Unit.Catalogue
{
    [TestFixture]
    internal class CurrentOffersTests
    {
        [Test]
        public void It_does_not_give_discount_when_deal_does_not_apply()
        {
            var items = new Collection<IPurchaseable> { new Bread(), new Butter()};
            var unit = new CurrentOffers();

            var deal = Substitute.For<IDeal>();
            deal.TimesApplicable(items).Returns(0);
            unit.RegisterDeal(deal, 100);

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(0));
        }

        [Test]
        public void It_gives_discount_when_deal_applies()
        {
            var items = new Collection<IPurchaseable> { new Bread(), new Butter()};
            var unit = new CurrentOffers();

            var deal = Substitute.For<IDeal>();
            deal.TimesApplicable(items).Returns(1);
            var discount = 100;
            unit.RegisterDeal(deal, discount);

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(-discount));
        }

        [Test]
        public void It_gives_discount_when_deal_applies_twice()
        {
            var items = new Collection<IPurchaseable> { new Bread(), new Butter()};
            var unit = new CurrentOffers();

            var deal = Substitute.For<IDeal>();
            var timesApplicable = 2;
            deal.TimesApplicable(items).Returns(timesApplicable);
            var discount = 100;
            unit.RegisterDeal(deal, discount);

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(-discount * timesApplicable));
        }
    }
}