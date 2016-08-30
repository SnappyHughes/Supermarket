using System;

namespace Supermarket
{
    public class Checkout
    {
        public int Total { get; private set; }

        private Item _itemA;
        private Item _itemB;

        public Checkout(Item itemA, Item itemB)
        {
            _itemA = itemA;
            _itemB = itemB; 
        }

        public void Scan(string item)
        {
            if(item == _itemA.Sku)
                Total = _itemA.Price;
            if (item == _itemB.Sku)
                Total = _itemB.Price;
        }
    }

    public class Item
    {
        public string Sku { get; private set; }
        public int Price { get; private set; }

        public Item(string sku, int price)
        {
            Sku = sku;
            Price = price;
        }
    }
}
