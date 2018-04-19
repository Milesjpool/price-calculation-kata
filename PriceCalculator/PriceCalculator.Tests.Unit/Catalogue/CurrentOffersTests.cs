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
        public void It_gives_no_discount_when_no_items_Are_bought()
        {
            var items = new Collection<IPurchaseable>();
            var unit = new CurrentOffers();

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(0));
        }
        
        [Test]
        public void It_gives_discount_when_deal_applies()
        {
            var items = new Collection<IPurchaseable> {new Butter(), new Bread(), new Butter()};
            var unit = new CurrentOffers();

            var deal = Substitute.For<IDeal>();
            deal.DealApplies(items).Returns(true);
            var discount = 100;
            unit.RegisterDeal(deal, discount);

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(-discount));
        }
        
        [Test]
        public void It_does_not_give_discount_when_deal_does_not_apply()
        {
            var items = new Collection<IPurchaseable> {new Butter(), new Bread(), new Butter()};
            var unit = new CurrentOffers();

            var deal = Substitute.For<IDeal>();
            deal.DealApplies(items).Returns(false);
            unit.RegisterDeal(deal, 100);

            Assert.That(unit.GetApplicable(items).NetPence, Is.EqualTo(0));
        }
    }
}