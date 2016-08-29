using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Supermarket.Test
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void GivenIScanSkuOfAItShouldGiveTotalOf50()
        {
            var checkout = new Checkout();
            const string skuOfA = "A";
            const int priceOfA = 50;

            checkout.Scan(skuOfA);

            Assert.AreEqual(priceOfA, checkout.Total);
        }
    }
}
