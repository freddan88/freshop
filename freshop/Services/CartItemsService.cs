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


        public CartItems Get(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return this.cartItemsRepository.Get(id);
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