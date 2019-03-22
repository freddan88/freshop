using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using freshop.Models;

namespace freshop.Repositories
{
    public class OrdersRepository
    {
        private string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Orders> Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Orders>("SELECT product_id, cart_guid, pn, img, model, quantity, price FROM cart_items LEFT JOIN products ON cart_items.product_id = products.id WHERE cart_guid = @guid", new { guid }).ToList();
            }
        }

    }
}