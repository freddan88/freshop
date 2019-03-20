using System;
using System.Collections.Generic;
using System.Web.Http;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class ProductsService
    {
        private ProductsRepository productsRepository;

        public ProductsService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public List<Products> Get()
        {
            return this.productsRepository.Get();
        }

        //public Products Get(string pn)
        //{
        //    return this.productsRepository.Get(pn);
        //}

        public List<Products> Get(string key)
        {
            return this.productsRepository.Get(key);
        }
    }
}