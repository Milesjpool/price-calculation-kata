using System.Collections.ObjectModel;
using System.Linq;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public class BreadAndButterDeal : IDeal
    {
        public bool DealApplies(Collection<IPurchaseable> purchases)
        {
            var hasBread = purchases.Count(p => p.GetType() == typeof (Bread)) >= 1;
            var hasButter = purchases.Count(p => p.GetType() == typeof (Butter)) >= 2;
            return hasBread && hasButter;
        }
    }
}