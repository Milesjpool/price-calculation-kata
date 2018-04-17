using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue
{
    public interface ICatalogue
    {
        Price LookupPrice(IPurchaseable purchaseable);
    }
}