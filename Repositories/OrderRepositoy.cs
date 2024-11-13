using HotPot1.Data;
using HotPot1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotPot1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodOrderingContext _context;

        public OrderRepository(FoodOrderingContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .ToListAsync();
        }
    }
}
