﻿using System;
namespace freshop.Models
{
    public class Orders
    {
        public int product_id { get; set; }
        public string cart_guid { get; set; }
        public string pn { get; set; }
        public string img { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }
}