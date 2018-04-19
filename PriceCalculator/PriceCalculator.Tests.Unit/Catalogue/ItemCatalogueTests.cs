using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Tests.Unit.Catalogue
{
    [TestFixture]
    class ItemCatalogueTests
    {
        [Test]
        public void It_returns_the_price_of_bread()
        {
            var unit = new ShopCatalogue();
            IPurchaseable item = new Bread();
            Assert.That(unit.LookupPrice(item).AsCurrency(), Is.EqualTo(1));
        }
        
        [Test]
        public void It_returns_the_price_of_butter()
        {
            var unit = new ShopCatalogue();
            IPurchaseable item = new Butter();
            Assert.That(unit.LookupPrice(item).AsCurrency(), Is.EqualTo(0.8));
        }
        
        [Test]
        public void It_returns_the_price_of_milk()
        {
            var unit = new ShopCatalogue();
            IPurchaseable item = new Milk();
            Assert.That(unit.LookupPrice(item).AsCurrency(), Is.EqualTo(1.15));
        }
    }
}
