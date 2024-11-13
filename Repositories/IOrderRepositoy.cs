using HotPot1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot1.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
    }
}

