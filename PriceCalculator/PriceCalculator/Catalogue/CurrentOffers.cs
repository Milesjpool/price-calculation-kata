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
            var applicableDeals = _deals.Where(dealDiscount => dealDiscount.Key.DealApplies(purchases));
            var applicableDiscount = applicableDeals.Aggregate(_noDiscount, (currentDiscount, deal) => currentDiscount.Add(new Discount(deal.Value)));
            return applicableDiscount;
        }

        public void RegisterDeal(IDeal deal, int discount)
        {
            _deals.Add(new KeyValuePair<IDeal, int>(deal, discount));
        }
    }
}