using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class Checkout
    {
        public int Total { get; private set; }
        
        private ItemPricing _itemPricing;

        private Discount _discount;

        public Checkout(ItemPricing itemPricing, Discount discount)
        {
            _itemPricing = itemPricing;
            _discount = discount;
        }

        public void Scan(string item)
        {
            Total += _itemPricing.GetPrice(item);
            
            if(item == _discount.SkuOfItem)
            {
                _discount.CurrentCount++;

                if (_discount.CurrentCount == _discount.QuantityNeeded)
                    Total -= _discount.DiscountAmount;
            }
        }
    }

    public class Discount
    {
        public string SkuOfItem { get; private set; }
        public int QuantityNeeded { get; private set; }
        public int DiscountAmount { get; private set; }
        public int CurrentCount { get; set; }

        public Discount(string skuOfItem, int quantityNeeded, int discountAmount)
        {
            SkuOfItem = skuOfItem;
            QuantityNeeded = quantityNeeded;
            DiscountAmount = discountAmount;
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
