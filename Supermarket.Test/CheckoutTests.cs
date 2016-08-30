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

        private Item _itemA = new Item(_skuOfA, _priceOfA);
        private Item _itemB = new Item(_skuOfB, _priceOfB);

        [TestMethod]
        public void GivenIScanSkuOfAItShouldGiveTotalOf50()
        {
            var checkout = new Checkout(_itemA, _itemB);

            checkout.Scan(_skuOfA);

            Assert.AreEqual(_priceOfA, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanSkuOfBItShouldGiveTotalOf30()
        {
            var checkout = new Checkout(_itemA, _itemB);

            checkout.Scan(_skuOfB);

            Assert.AreEqual(_priceOfB, checkout.Total);
        }

    }
}
