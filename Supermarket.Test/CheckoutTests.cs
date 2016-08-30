using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Supermarket.Test
{
    [TestClass]
    public class CheckoutTests
    {
        private const string _skuOfA = "A";
        private const int _priceOfA = 50;

        private const string _skuOfB = "B";
        private const int _priceOfB = 30;

        private const string _skuOfC = "C";
        private const int _priceOfC = 15;

        private Item _itemA = new Item(_skuOfA, _priceOfA);
        private Item _itemB = new Item(_skuOfB, _priceOfB);
        private Item _itemC = new Item(_skuOfC, _priceOfC);

        private ItemPricing _itemPricing = new ItemPricing();

        [TestMethod]
        public void GivenIScanSkuOfAItShouldGiveTotalOf50()
        {
            var checkout = new Checkout(_itemPricing);

            _itemPricing.AddRule(_itemA);
            checkout.Scan(_skuOfA);

            Assert.AreEqual(_priceOfA, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanSkuOfBItShouldGiveTotalOf30()
        {
            var checkout = new Checkout(_itemPricing);

            _itemPricing.AddRule(_itemB);
            checkout.Scan(_skuOfB);

            Assert.AreEqual(_priceOfB, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanToSkuOfAItShouldGiveTotalOf100()
        {
            var checkout = new Checkout(_itemPricing);
            var expectedResult = 100;

            _itemPricing.AddRule(_itemA);
            checkout.Scan(_skuOfA);
            checkout.Scan(_skuOfA);

            Assert.AreEqual(expectedResult, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanSkuOfCItShouldGiveTotalOf15()
        {
            var checkout = new Checkout(_itemPricing);

            _itemPricing.AddRule(new Item("C", 15));
            checkout.Scan("C");

            Assert.AreEqual(15, checkout.Total);
        }
    }
}
