using System;
using System.Collections.Generic;
using freshop.Models;

namespace freshop.Models
{
    public class Order
    {
        public OrderValue orderValue { get; set; }
        public Orders orders { get; set; }
        public Customer customer { get; set; }
        public List<OrderItems> orderItems { get; set; }
    }
}