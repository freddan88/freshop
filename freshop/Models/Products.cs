using System;
namespace freshop.Models
{
    public class Products
    {
        public int id { get; set; }
        public string pn { get; set; }
        public int qty { get; set; }
        public string img { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public string desc { get; set; }
        public string specs { get; set; }
    }
}