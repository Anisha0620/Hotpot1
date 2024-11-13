using HotPot1.Data;
using HotPot1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotPot1.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly FoodOrderingContext _context;

        public CartRepository(FoodOrderingContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.MenuItem)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}

