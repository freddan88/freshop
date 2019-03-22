using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using SQLitePCL;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using freshop.Services;
using freshop.Models;
using freshop.Repositories;

namespace freshop.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsService productsService;
        private readonly string connectionString;

        public ProductsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var products = this.productsService.Get();
            return Ok(products);
        }

        [HttpGet("{key}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string key)
        {
            var resault = this.productsService.Get(key);
            return Ok(resault);
        }
    }
}