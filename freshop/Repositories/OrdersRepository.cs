using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using freshop.Models;

namespace freshop.Repositories
{
    public class OrdersRepository
    {
        private readonly string connectionString;
        public OrdersRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<Orders> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Orders>("SELECT * FROM orders").ToList();
            }
        }

        public Orders Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Orders>("SELECT *, id AS order_nr FROM orders WHERE cart_guid = @guid", new { guid });
            }
        }

        public void Add(Orders Orders)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO orders (cart_guid) VALUES (@cart_guid)", Orders);
            }
        }
    }
}