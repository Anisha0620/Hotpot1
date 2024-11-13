using HotPot1.Models;
using HotPot1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // Get Cart for current user
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = User.FindFirst("id")?.Value;
            if (userId == null)
                return Unauthorized();

            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return Ok(cart);
        }

        // Add Item to Cart
        [HttpPost("add")]
        public async Task<IActionResult> AddItemToCart([FromBody] CartItem cartItem)
        {
            if (cartItem == null || !ModelState.IsValid)
                return BadRequest("Invalid item data.");

            await _cartRepository.AddCartItemAsync(cartItem);
            return Ok("Item added to cart");
        }

        // Remove Item from Cart
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveItemFromCart([FromBody] CartItem cartItem)
        {
            if (cartItem == null || !ModelState.IsValid)
                return BadRequest("Invalid item data.");

            await _cartRepository.RemoveCartItemAsync(cartItem);
            return Ok("Item removed from cart");
        }
    }
}
