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
    public class OrderValueController : Controller
    {
        private readonly OrderValueService orderValueService;

        public OrderValueController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderValueService = new OrderValueService(new OrderValueRepository(connectionString));
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(OrderValue), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.orderValueService.Get(guid);
            return Ok(resault);
        }
    }
}