using HotPot1.Models;
using HotPot1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        // Get all menu items
        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            var items = await _menuRepository.GetAllMenuItemsAsync();
            return Ok(items);
        }

        // Get a single menu item by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            var item = await _menuRepository.GetMenuItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // Add a menu item
        [HttpPost]
        public async Task<IActionResult> AddMenuItem([FromBody] MenuItem menuItem)
        {
            if (menuItem == null || !ModelState.IsValid)
                return BadRequest("Invalid menu item data.");

            await _menuRepository.AddMenuItemAsync(menuItem);
            return Ok("Menu item added successfully.");
        }

        // Update menu item
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItem menuItem)
        {
            if (id != menuItem.Id || !ModelState.IsValid)
                return BadRequest("Invalid menu item data.");

            await _menuRepository.UpdateMenuItemAsync(menuItem);
            return Ok("Menu item updated successfully.");
        }

        // Delete menu item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            await _menuRepository.DeleteMenuItemAsync(id);
            return Ok("Menu item deleted successfully.");
        }
    }
}
