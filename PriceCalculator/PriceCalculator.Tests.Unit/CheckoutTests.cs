using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace PriceCalculator.Tests.Unit
{
    [TestFixture]
    class CheckoutTests
    {
        [Test]
        public void It_scans_a_basket()
        {
            var basket = Substitute.For<Basket>();
            
            var unit = new Checkout();

            Assert.DoesNotThrow(() => unit.Scan(basket));
        }

        [Test]
        public void It_holds_a_total()
        {
            var unit = new Checkout();
            Assert.That(unit.Total, Is.Not.Null);
        }
    }
}
