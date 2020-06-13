using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium.Service;

namespace PrzykladoweKolokwium.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class GetOrdersController : ControllerBase
    {
        private IDbService dbService;

        public GetOrdersController (IDbService service)
        {
            dbService = service;
        }
        [HttpGet]
        public IActionResult getOrders(string name)
        {
            try
            {
            
                    return Ok(dbService.GetOrders(name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}