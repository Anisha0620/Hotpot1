using HotPot1.Models;
using HotPot1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // Create an order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null || !ModelState.IsValid)
                return BadRequest("Invalid order data.");

            await _orderRepository.CreateOrderAsync(order);
            return Ok("Order created successfully.");
        }

        // Get orders for the current user
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId == null)
                return Unauthorized();

            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }
    }
}
