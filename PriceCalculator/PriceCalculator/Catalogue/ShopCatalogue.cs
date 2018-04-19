using System;
using System.Collections.Generic;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Catalogue
{
    public class ShopCatalogue : ICatalogue
    {
        private readonly IDictionary<Type, Price> _prices = new Dictionary<Type, Price>
        {
            {typeof(Bread), new Price(100)},
            {typeof(Butter), new Price(80)},
            {typeof(Milk), new Price(115)}
        }; 

        public Price LookupPrice(IPurchaseable item)
        {
            if (!_prices.ContainsKey(item.GetType()))
                throw new ItemNotFound();
            return _prices[item.GetType()];
        }
    }
}