using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using freshop.Models;
using freshop.Repositories;
using freshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace freshop.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly string connectionString;
        private readonly OrdersServices OrdersService;

        public OrdersController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.OrdersService = new OrdersServices(new OrdersRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Orders>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(this.OrdersService.Get());
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.OrdersService.Get(guid);
            return Ok(resault);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Orders Orders)
        {
            var result = this.OrdersService.Add(Orders);

            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}