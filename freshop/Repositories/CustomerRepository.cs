using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using freshop.Models;

namespace freshop.Repositories
{
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(string connectionstring)
        {
            this.connectionString = connectionstring;
        }

        public List<Customer> Get()
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Customer>("SELECT * FROM customers").ToList();
            }
        }

        public Customer Get(string guid)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Customer>("SELECT id, fname, lname, adress, zip, city, cart_guid, email FROM customers WHERE cart_guid = @guid", new { guid });
            }
        }

        public void Add(Customer costumer)
        {
            using (var connection = new SQLiteConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO customers (fname, lname, adress, zip, city, cart_guid, email) VALUES (@fname, @lname, @adress, @zip, @city, @cart_guid, @email)", costumer);
            }
        }
    }
}