using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator.Catalogue.Deals
{
    public class BreadAndButterDeal : IDeal
    {
        public int TimesApplicable(Collection<IPurchaseable> purchases)
        {
            return Math.Min(ButterCount(purchases)/2, BreadCount(purchases));
        }

        private static int ButterCount(IEnumerable<IPurchaseable> purchases)
        {
            return purchases.Count(p => p.GetType() == typeof (Butter));
        }

        private static int BreadCount(IEnumerable<IPurchaseable> purchases)
        {
            return purchases.Count(p => p.GetType() == typeof (Bread));
        }
    }
}