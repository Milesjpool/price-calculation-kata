using System;

namespace PriceCalculator
{
    public class Price
    {
        private const int PenceInPound = 100;
        private readonly int _pence;

        public Price():this(0)
        {
        }

        public Price(int pence)
        {
            _pence = pence;
        }

        public decimal InPounds()
        {
            return (decimal)_pence/PenceInPound;
        }

        public Price Add(Price other)
        {
            return new Price(_pence + other._pence);
        }
    }
}