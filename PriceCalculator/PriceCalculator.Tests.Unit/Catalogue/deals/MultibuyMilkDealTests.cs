using System.Collections.ObjectModel;
using NUnit.Framework;
using PriceCalculator.Catalogue.Deals;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Unit.Catalogue.deals
{
    [TestFixture]
    public class MultibuyMilkDealTests
    {
        [Test]
        public void It_does_not_apply_to_three_milks()
        {
            var items = new Collection<IPurchaseable> { new Milk(), new Milk(), new Milk()};
            var unit = new MultibuyMilkDeal();

            Assert.That(unit.TimesEligible(items), Is.EqualTo(0));
        }

        [Test]
        public void It_applies_to_four_milks()
        {
            var items = new Collection<IPurchaseable> { new Milk(), new Milk(), new Milk(), new Milk() };
            var unit = new MultibuyMilkDeal();

            Assert.That(unit.TimesEligible(items), Is.EqualTo(1));
        }

        [Test]
        public void It_applies_to_five_milks_and_a_butter()
        {
            var items = new Collection<IPurchaseable> { new Butter(), new Milk(), new Milk(), new Milk(), new Milk(), new Milk() };
            var unit = new MultibuyMilkDeal();

            Assert.That(unit.TimesEligible(items), Is.EqualTo(1));
        }

        [Test]
        public void It_applies_twice_to_nine_milks_and_a_butter()
        {
            var items = new Collection<IPurchaseable> { 
                new Butter(), new Milk(), new Milk(), new Milk(), new Milk(),
                new Milk(), new Milk(), new Milk(), new Milk(), new Milk() };
            var unit = new MultibuyMilkDeal();

            Assert.That(unit.TimesEligible(items), Is.EqualTo(2));
        }
    }
}