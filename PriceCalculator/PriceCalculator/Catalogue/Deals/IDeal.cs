using System.Collections.ObjectModel;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public interface IDeal
    {
        int TimesApplicable(Collection<IPurchaseable> purchases);
    }
}