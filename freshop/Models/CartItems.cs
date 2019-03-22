using System;
namespace freshop.Models
{
    public class CartItems
    {
        public string cart_guid { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}