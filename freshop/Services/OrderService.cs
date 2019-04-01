using System;
using System.Collections.Generic;
using System.Web.Http;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class OrderService
    {
        private readonly CustomerRepository customerRepository;
        private readonly OrderValueRepository orderValueRepository;
        private readonly OrdersRepository ordersRepository;
        private readonly OrderItemsRepository orderItemsRepository;

        public OrderService(CustomerRepository customerRepository, OrderValueRepository orderValueRepository, OrdersRepository ordersRepository, OrderItemsRepository orderItemsRepository)
        {
            this.customerRepository = customerRepository;
            this.orderValueRepository = orderValueRepository;
            this.ordersRepository = ordersRepository;
            this.orderItemsRepository = orderItemsRepository;

        }

        public Order Get(string guid)
        {
            var customer = this.customerRepository.Get(guid);
            var orderValue = this.orderValueRepository.Get(guid);
            var orders = this.ordersRepository.Get(guid);
            var orderItems = this.orderItemsRepository.Get(guid);

            return new Order
            {
                customer = customer,
                orderValue = orderValue,
                orders = orders,
                orderItems = orderItems
            };
        }
    }
}