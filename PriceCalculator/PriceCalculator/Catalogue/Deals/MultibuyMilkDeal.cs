using System.Collections.ObjectModel;
using System.Linq;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public class MultibuyMilkDeal : IDeal
    {
        public bool DealApplies(Collection<IPurchaseable> purchases)
        {
            return purchases.Count(p => p.GetType() == typeof(Milk)) >= 4;
        }
    }
}