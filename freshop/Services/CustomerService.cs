using System;
using System.Collections.Generic;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class CustomerServices
    {
        private readonly CustomerRepository customerRepository;

        public CustomerServices(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Customer> Get()
        {
            return this.customerRepository.Get();
        }

        public Customer Get(string guid)
        {
            return this.customerRepository.Get(guid);
        }

        public bool Add(Customer customer)
        {
            if (customer != null)
            {
                this.customerRepository.Add(customer);
                return true;
            }

            return false;
        }
    }
}