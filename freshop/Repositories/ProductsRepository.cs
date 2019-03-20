using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using freshop.Models;

namespace freshop.Repositories
{
    public class ProductsRepository
    {
        private string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Products> Get()
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM products").ToList();
            }
        }

        //public Products Get(string pn)
        //{
        //    using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
        //    {
        //        return connection.QuerySingleOrDefault<Products>("SELECT * FROM products WHERE pn = @pn", new { pn });
        //    }
        //}

        public List<Products> Get(string key)
        {
            using (SQLiteConnection connection = new SQLiteConnection(this.connectionString))
            {
                return connection.Query<Products>("SELECT * FROM products WHERE pn = @key OR category = @key", new { key }).ToList();
            }
        }

    }
}