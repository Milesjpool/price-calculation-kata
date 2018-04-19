﻿using NUnit.Framework;
using PriceCalculator.Catalogue;
using PriceCalculator.Catalogue.Deals;
using PriceCalculator.Catalogue.Purchaseables;
using PriceCalculator.Pricing;

namespace PriceCalculator.Tests.Acceptance.Scenarios
{
    public partial class BasketPricing
    {
        private Basket _basket;
        private Price _total;
        private Checkout _checkout;

        [SetUp]
        public void BeforeEach()
        {
            _basket = new Basket();
            var shopCatalogue = new ShopCatalogue();
            var currentOffers = new CurrentOffers();
            currentOffers.RegisterDeal(new BreadAndButterDeal(), shopCatalogue.LookupPrice(new Bread()).NetPence/2);
            currentOffers.RegisterDeal(new MultibuyMilkDeal(), shopCatalogue.LookupPrice(new Milk()).NetPence);
            _checkout = new Checkout(shopCatalogue, currentOffers);           
        }

        private void GivenTheBasketHasBread()
        {
            _basket.Put(new Bread());
        }

        private void GivenTheBasketHasBread(int breads)
        {
            for (int i = 0; i < breads; i++)
                GivenTheBasketHasBread();
        }

        private void GivenTheBasketHasButter()
        {
            _basket.Put(new Butter());
        }

        private void GivenTheBasketHasButter(int butters)
        {
            for (int i = 0; i < butters; i++)
                GivenTheBasketHasButter();
        }

        private void GivenTheBasketHasMilk()
        {
            _basket.Put(new Milk());
        }

        private void GivenTheBasketHasMilk(int milks)
        {
            for (int i = 0; i < milks; i++)
                GivenTheBasketHasMilk();
        }

        private void WhenITotalTheBasket()
        {
            _checkout.Scan(_basket);
            _total = _checkout.GetTotal();
        }

        private void ThenTheTotalShouldBe(double expectedTotal)
        {
            Assert.That(_total.AsCurrency(), Is.EqualTo(expectedTotal));
        }

        private BasketPricing And { get { return this; } }
    }
}
