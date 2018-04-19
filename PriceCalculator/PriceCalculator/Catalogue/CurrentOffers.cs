using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PriceCalculator.Catalogue.Deals;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Catalogue
{
    public class CurrentOffers : IDiscounts
    {
        private readonly Discount _noDiscount = new Discount(0);
        private readonly Collection<KeyValuePair<IDeal, int>> _deals;

        public CurrentOffers()
        {
            _deals = new Collection<KeyValuePair<IDeal, int>>();
        }

        public Discount GetApplicable(Collection<IPurchaseable> purchases)
        {
            var applicableDiscount = _deals.Aggregate(_noDiscount, (currentDiscount, deal) => currentDiscount.Add(GetApplicableDiscount(purchases, deal)));
            return applicableDiscount;
        }

        private static Discount GetApplicableDiscount(Collection<IPurchaseable> purchases, KeyValuePair<IDeal, int> deal)
        {
            return new Discount(deal.Key.TimesApplicable(purchases) * deal.Value);
        }

        public void RegisterDeal(IDeal deal, int discount)
        {
            _deals.Add(new KeyValuePair<IDeal, int>(deal, discount));
        }
    }
}