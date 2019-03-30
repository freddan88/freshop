using System;
namespace freshop.Models
{
    public class OrderItems
    {
        public int product_id { get; set; }
        public string pn { get; set; }
        public string img { get; set; }
        public string model { get; set; }
        public int total_qty { get; set; }
        public int piece_price { get; set; }
        public int total_price { get; set; }
    }
}