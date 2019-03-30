using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using freshop.Models;

namespace freshop.Repositories
{
    public class OrderItemsRepository
    {
        private string connectionString;

        public OrderItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<OrderItems> Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<OrderItems>("SELECT product_id, pn, img, model, SUM(quantity) AS total_qty, price AS piece_price, SUM(prices) AS total_price FROM(SELECT product_id, cart_guid, pn, img, model, quantity, price, quantity * price AS prices FROM cart_items LEFT JOIN products ON cart_items.product_id = products.id WHERE cart_guid = @guid) GROUP BY product_id", new { guid }).ToList();
            }
        }
    }
}