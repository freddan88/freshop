using System;
namespace freshop.Models
{
    public class Orders
    {
        public int id { get; set; }
        public int order_nr { get; set; }
        public string placed_on { get; set; }
        public string cart_guid { get; set; }
    }
}