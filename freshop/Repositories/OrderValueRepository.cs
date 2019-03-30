using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using freshop.Models;

namespace freshop.Repositories
{
    public class OrderValueRepository
    {
        private string connectionString;

        public OrderValueRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public OrderValue Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<OrderValue>("SELECT SUM(total_price) AS order_value FROM(SELECT products.price * cart_items.quantity AS total_price FROM cart_items LEFT JOIN products ON cart_items.product_id = products.id WHERE cart_items.cart_guid = @guid)", new { guid });
            }
        }
    }
}