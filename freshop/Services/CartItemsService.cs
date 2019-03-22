using System;
using System.Collections.Generic;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Services
{
    public class CartItemsServices
    {
        private readonly CartItemsRepository cartItemsRepository;

        public CartItemsServices(CartItemsRepository cartItemsRepository)
        {
            this.cartItemsRepository = cartItemsRepository;

        }

        public List<CartItems> Get()
        {
            return this.cartItemsRepository.Get();
        }

        // public List<CartItems> Get(string guid)
        public CartItems Get(string guid)
        {
            return this.cartItemsRepository.Get(guid);
        }

        public bool Add(CartItems cartItems)
        {
            if (cartItems != null)
            {
                this.cartItemsRepository.Add(cartItems);
                return true;
            }

            return false;
        }

    }
}