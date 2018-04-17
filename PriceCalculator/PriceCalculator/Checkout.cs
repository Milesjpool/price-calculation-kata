using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator
{
    public class Checkout
    {
        private readonly ICatalogue _itemCatalogue;
        public Price Total { get; private set; }

        public Checkout(ICatalogue catalogue)
        {
            Total = new Price();
            _itemCatalogue = catalogue;
        }

        public void Scan(IScannable basket)
        {
            var item = basket.TakeItem();
            while (item != null)
            {
                var itemPrice = _itemCatalogue.LookupPrice(item);
                Total = Total.Add(itemPrice);
                item = basket.TakeItem();
            }
        }
    }
}