using System.Collections.ObjectModel;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator
{
    public class Checkout
    {
        private readonly ICatalogue _itemCatalogue;
        private readonly IDiscounts _discounts;
        private readonly Collection<IPurchaseable> _scannedItems;
        private Price _subtotal;

        public Checkout(ICatalogue catalogue, IDiscounts discounts)
        {
            _subtotal = new Price();
            _scannedItems = new Collection<IPurchaseable>();
            _itemCatalogue = catalogue;
            _discounts = discounts;
        }

        public void Scan(IScannable basket)
        {
            for (var item = basket.TakeItem(); item != null; item = basket.TakeItem())
            {
                ScanItem(item);
            }
        }

        private void ScanItem(IPurchaseable item)
        {
            var itemPrice = _itemCatalogue.LookupPrice(item);
            _subtotal = _subtotal.Add(itemPrice);
            _scannedItems.Add(item);
        }

        public Price GetTotal()
        {
            IPriceIncrement discount = _discounts.GetApplicable(_scannedItems);
            return _subtotal.Add(discount);
        }
    }
}