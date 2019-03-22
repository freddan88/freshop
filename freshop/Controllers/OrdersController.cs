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
    public class OrdersController : Controller
    {
        private readonly OrdersService ordersService;
        private readonly string connectionString;

        public OrdersController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.ordersService = new OrdersService(new OrdersRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(Products), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.ordersService.Get(guid);
            return Ok(resault);
        }
    }
}