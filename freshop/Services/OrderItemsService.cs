using System;
using System.Collections.Generic;
using System.Web.Http;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class OrderItemsService
    {
        private OrderItemsRepository orderItemsRepository;

        public OrderItemsService(OrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }

        public List<OrderItems> Get(string guid)
        {
            return this.orderItemsRepository.Get(guid);
        }
    }
}