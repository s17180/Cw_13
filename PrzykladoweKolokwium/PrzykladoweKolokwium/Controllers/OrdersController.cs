using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium.DTOs.Requests;
using PrzykladoweKolokwium.Service;

namespace PrzykladoweKolokwium.Controllers
{
    [Route("api/app]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IDbService dbService;

        public OrdersController(IDbService service)
        {
            dbService = service;
        }
        [HttpPost("{id}/orders")]
        public IActionResult AddNewOrder(int id, AddOrderReq request)
        {
            try
            {
                return Ok(dbService.AddOrder(id, request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}