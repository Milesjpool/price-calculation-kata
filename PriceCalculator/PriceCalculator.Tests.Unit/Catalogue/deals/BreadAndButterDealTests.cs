using System.Collections.ObjectModel;
using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Deals;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Unit.Catalogue.deals
{
    [TestFixture]
    class BreadAndButterDealTests
    {
        [Test]
        public void It_does_not_apply_to_a_bread_and_a_butter()
        {
            var items = new Collection<IPurchaseable> { new Butter(), new Bread() };
            var unit = new BreadAndButterDeal();

            Assert.That(unit.DealApplies(items), Is.False);   
        }

        [Test]
        public void It_applies_to_two_breads_and_a_butter()
        {
            var items = new Collection<IPurchaseable> { new Butter(), new Bread(), new Butter() };
            var unit = new BreadAndButterDeal();

            Assert.That(unit.DealApplies(items), Is.True);   
        }

        [Test]
        public void It_applies_to_two_breads_and_two_butter()
        {
            var items = new Collection<IPurchaseable> { new Butter(), new Bread(), new Butter(), new Bread() };
            var unit = new BreadAndButterDeal();

            Assert.That(unit.DealApplies(items), Is.True);   
        }
    }
}
