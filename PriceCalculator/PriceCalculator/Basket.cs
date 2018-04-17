using System.Collections.Generic;
using System.Linq;
using PriceCalculator.Catalogue.Purchaseables;

namespace PriceCalculator
{
    public class Basket : IScannable
    {
        private readonly Stack<IPurchaseable> _items = new Stack<IPurchaseable>();

        public void Put(IPurchaseable item)
        {
            _items.Push(item);
        }

        public IPurchaseable TakeItem()
        {
            return _items.Any() ? _items.Pop() : null;
        }
    }

    public interface IScannable
    {
        void Put(IPurchaseable item);
        IPurchaseable TakeItem();
    }
}