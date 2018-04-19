using System.Collections.ObjectModel;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public interface IDeal
    {
        int TimesEligible(Collection<IPurchaseable> purchases);
    }
}