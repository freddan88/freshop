using System;
using System.Collections.Generic;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class OrdersServices
    {
        private readonly OrdersRepository OrdersRepository;
        public OrdersServices(OrdersRepository OrdersRepository)
        {
            this.OrdersRepository = OrdersRepository;
        }

        public List<Orders> Get()
        {
            return this.OrdersRepository.Get();
        }

        public Orders Get(string guid)
        {
            return this.OrdersRepository.Get(guid);
        }

        public bool Add(Orders Orders)
        {
            if (Orders != null)
            {
                this.OrdersRepository.Add(Orders);
                return true;
            }
            return false;
        }
    }
}