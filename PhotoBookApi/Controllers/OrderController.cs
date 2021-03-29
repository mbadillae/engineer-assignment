using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PhotoBookApi.Helper;
using PhotoBookApi.Models;
using PhotoBookApi.Repositories;
using PhotoBookApi.Services;

namespace PhotoBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly OrderContext _context;
        private readonly ILogger<OrderController> _logger;

        public OrderController(OrderContext context, ILogger<OrderController> logger, IOrderService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        // GET: api/Order/5
        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(string orderId)
        {
            try
            {
                var response = await _service.GetOrderAsync(orderId);

                if ((response == null) || string.IsNullOrEmpty(response.OrderId))
                {
                    //TODO: Change this OkObject result to retrieve 404 error
                    var x = Ok($"No data found for order {orderId}");
                    return x;
                    ///return Ok($"No data found for order {orderId}");
                }
    
                return Ok(response);
            }
            catch(Exception ex)
            {
                Guid g = Guid.NewGuid();
                _logger.LogInformation($"Exception performing get operation: {ex.Message}", g);
                return Ok($"An error ocurred, please review log id {g}");
            }
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try{
                if(! ModelState.IsValid) { // re-render the view when validation failed.
                    return BadRequest("Model is not valid");
                }

                if (_service.OrderExists(order.OrderId))
                {
                    return BadRequest("Order already placed!!"); // TODO: Create custom message
                }
                else
                {
                    _service.SaveOrder(order);
                    return Ok($"The order with Id {order.OrderId } was submitted");
                }
            }
            catch(Exception ex)
            {
                Guid g = Guid.NewGuid();
                _logger.LogInformation($"Exception performing post{ex.Message}", g);
                return Ok($"An error ocurred, please review log id {g}");
            }             
        }
    }
}
