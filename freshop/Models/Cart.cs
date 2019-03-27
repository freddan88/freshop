using System;
namespace freshop.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string product_guid { get; set; }
        public string cart_guid { get; set; }
        public string pn { get; set; }
        public string img { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}