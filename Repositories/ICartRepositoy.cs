using HotPot1.Models;
using System.Threading.Tasks;

namespace HotPot1.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task AddCartItemAsync(CartItem cartItem);
        Task RemoveCartItemAsync(CartItem cartItem);
    }
}

