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
    public class CustomerController : Controller
    {
        private readonly string connectionString;
        private readonly CustomerServices customerService;

        public CustomerController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.customerService = new CustomerServices(new CustomerRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
        public IActionResult Get()

        {
            return Ok(this.customerService.Get());
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseTypeAttribute(StatusCodes.Status404NotFound)]
        public IActionResult Get(string guid)
        {
            var resault = this.customerService.Get(guid);
            return Ok(resault);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Customer customer)
        {
            var result = this.customerService.Add(customer);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}