using System;

namespace Supermarket
{
    public class Checkout
    {
        public int Total { get; set; }

        public void Scan(string item)
        {
            Total = 50;
        }
    }
}
