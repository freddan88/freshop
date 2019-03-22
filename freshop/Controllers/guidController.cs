using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace freshop.Repositories
{
    [Route("api/[controller]")]
    public class myGuidController : Controller
    {
        [HttpGet]
        public Guid Get()
        {
            Guid guid;
            guid = Guid.NewGuid();
            return guid;
        }
    }
}