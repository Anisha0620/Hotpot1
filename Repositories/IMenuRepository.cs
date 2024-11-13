using HotPot1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot1.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem> GetMenuItemByIdAsync(int id);
        Task AddMenuItemAsync(MenuItem menuItem);
        Task UpdateMenuItemAsync(MenuItem menuItem);
        Task DeleteMenuItemAsync(int id);
    }
}

