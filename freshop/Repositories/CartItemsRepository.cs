using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using freshop.Models;

namespace freshop.Repositories
{
    public class CartItemsRepository
    {
        private readonly string connectionString;

        public CartItemsRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<CartItems> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<CartItems>("SELECT * FROM cart_items").ToList();
            }
        }

        public CartItems Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<CartItems>("SELECT cart_guid, COUNT(product_id) AS items FROM cart_items WHERE cart_guid = @guid", new { guid });
            }
        }

        public void Add(CartItems cartItems)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cart_items (cart_guid, product_id, product_guid, quantity) VALUES (@cart_guid, @product_id, 'product_' || @product_guid, @quantity)", cartItems);
            }
        }

        public void Del(int id)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM cart_items WHERE id = @id", new { id });
            }
        }
    }
}