using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Supermarket.Test
{
    [TestClass]
    public class CheckoutTests : CheckoutBase
    {
        [TestMethod]
        public void GivenIScanSkuOfAItShouldGiveTotalOf50()
        {
            var checkout = new Checkout(_itemPricing, _discount);

            _itemPricing.AddRule(_itemA);
            checkout.Scan(_skuOfA);

            Assert.AreEqual(_priceOfA, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanSkuOfBItShouldGiveTotalOf30()
        {
            var checkout = new Checkout(_itemPricing, _discount);

            _itemPricing.AddRule(_itemB);
            checkout.Scan(_skuOfB);

            Assert.AreEqual(_priceOfB, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanToSkuOfAItShouldGiveTotalOf100()
        {
            var checkout = new Checkout(_itemPricing, _discount);
            var expectedResult = 100;

            _itemPricing.AddRule(_itemA);
            checkout.Scan(_skuOfA);
            checkout.Scan(_skuOfA);

            Assert.AreEqual(expectedResult, checkout.Total);
        }

        [TestMethod]
        public void GivenIScanSkuOfCItShouldGiveTotalOf15()
        {
            var checkout = new Checkout(_itemPricing, _discount);

            _itemPricing.AddRule(new Item("C", 15));
            checkout.Scan("C");

            Assert.AreEqual(15, checkout.Total);
        }

        [TestMethod]
        public void GivenIScan3SkusOfAItShouldGiveTotalOf130()
        {
            var checkout = new Checkout(_itemPricing, _discount);
            _itemPricing.AddRule(_itemA);

            checkout.Scan(_skuOfA);
            checkout.Scan(_skuOfA);
            checkout.Scan(_skuOfA);

            Assert.AreEqual(130, checkout.Total);
        }
    }
}
