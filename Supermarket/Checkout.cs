using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class Checkout
    {
        public int Total { get; private set; }
        
        private ItemPricing _itemPricing;

        private DiscountSet _discountRules;

        public Checkout(ItemPricing itemPricing, DiscountSet discountSet)
        {
            _itemPricing = itemPricing;
            _discountRules = discountSet;
        }

        public void Scan(string item)
        {
            Total += _itemPricing.GetPrice(item);

            CheckForDiscount(item);
        }

        private void CheckForDiscount(string item)
        {
            var discount = _discountRules.Rules.Find(d => d.SkuOfItem == item);

            if (discount != null)
            {
                discount.CurrentCount++;
                if (discount.CurrentCount % discount.QuantityNeeded == 0)
                    Total -= discount.DiscountAmount;
            }
        }
    }

    public class DiscountSet
    {
        public List<Discount> Rules { get; private set; }

        public DiscountSet()
        {
            if (Rules == null)
                Rules = new List<Discount>();
        }

        public void AddRule(Discount newDiscount)
        {
            Rules.Add(newDiscount);
        }

        public Discount GetDiscount(string skuOfItem)
        {
            return Rules.Find(d => d.SkuOfItem == skuOfItem);
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
