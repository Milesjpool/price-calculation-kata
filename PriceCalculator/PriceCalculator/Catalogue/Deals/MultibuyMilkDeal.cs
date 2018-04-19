using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public class MultibuyMilkDeal : IDeal
    {
        public int TimesEligible(Collection<IPurchaseable> purchases)
        {
            return MilkCount(purchases)/4;
        }

        private static int MilkCount(IEnumerable<IPurchaseable> purchases)
        {
            return purchases.Count(p => p.GetType() == typeof(Milk));
        }
    }
}