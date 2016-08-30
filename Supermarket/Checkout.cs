using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class Checkout
    {
        public int Total { get; private set; }
        
        private ItemPricing _itemPricing;

        public Checkout(ItemPricing itemPricing)
        {
            _itemPricing = itemPricing;
        }

        public void Scan(string item)
        {
            Total += _itemPricing.GetPrice(item);
        }
    }

    public class ItemPricing
    {
        public List<Item> Rules { get; private set; }

        public ItemPricing()
        {
            if (Rules == null)
                Rules = new List<Item>();
        }

        public void AddRule(Item newItem)
        {
            Rules.Add(newItem);
        }

        public int GetPrice(string skuOfItem)
        {
            return Rules.Find(i => i.Sku == skuOfItem).Price;
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
