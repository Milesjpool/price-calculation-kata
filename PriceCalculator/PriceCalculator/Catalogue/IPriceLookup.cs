using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Catalogue
{
    public interface ICatalogue
    {
        Price LookupPrice(IPurchaseable purchaseable);
    }
}