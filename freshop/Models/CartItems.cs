using System;
namespace freshop.Models
{
    public class CartItems
    {
        public int id { get; set; }
        public string cart_guid { get; set; }
        public int product_id { get; set; }
        public string product_guid { get; set; }
        public int quantity { get; set; }
        public int items { get; set; }
    }
}