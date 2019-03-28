using System;
namespace freshop.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string adress { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string cart_guid { get; set; }
        public string email { get; set; }
    }
}