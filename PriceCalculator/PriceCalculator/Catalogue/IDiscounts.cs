using System.Collections.ObjectModel;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Catalogue
{
    public interface IDiscounts
    {
        Discount GetApplicable(Collection<IPurchaseable> purchases);
    }
}