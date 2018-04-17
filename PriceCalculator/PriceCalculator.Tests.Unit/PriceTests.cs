using NUnit.Framework;

namespace PriceCalculator.Tests.Unit
{
    [TestFixture]
    class PriceTests
    {
        [Test]
        public void It_can_be_read_in_pounds()
        {
            var unit = new Price();
            Assert.That(unit.InPounds(), Is.Not.Null);
        }
    }
}
