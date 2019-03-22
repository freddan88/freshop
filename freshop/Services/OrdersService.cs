using System;
using System.Collections.Generic;
using System.Web.Http;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class OrdersService
    {
        private OrdersRepository OrdersRepository;
        private OrdersRepository ordersRepository;

        public OrdersService(OrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public List<Orders> Get(string guid)
        {
            return this.ordersRepository.Get(guid);
        }
    }
}