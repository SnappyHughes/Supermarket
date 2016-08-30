using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Test
{
    public class CheckoutBase
    {
        public const string _skuOfA = "A";
        public const int _priceOfA = 50;

        public const string _skuOfB = "B";
        public const int _priceOfB = 30;

        public const string _skuOfC = "C";
        public const int _priceOfC = 15;

        public Item _itemA = new Item(_skuOfA, _priceOfA);
        public Item _itemB = new Item(_skuOfB, _priceOfB);
        public Item _itemC = new Item(_skuOfC, _priceOfC);

        public ItemPricing _itemPricing = new ItemPricing();

        public Discount _discount = new Discount(_skuOfA, 3, 20);
    }
}
