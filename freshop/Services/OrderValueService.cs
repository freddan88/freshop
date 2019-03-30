using System;
using System.Collections.Generic;
using System.Web.Http;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class OrderValueService
    {
        private OrderValueRepository orderValueRepository;

        public OrderValueService(OrderValueRepository orderValueRepository)
        {
            this.orderValueRepository = orderValueRepository;
        }

        public OrderValue Get(string guid)
        {
            return this.orderValueRepository.Get(guid);
        }
    }
}