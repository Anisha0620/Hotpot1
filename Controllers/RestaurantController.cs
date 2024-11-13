using HotPot1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly List<Restaurant> _restaurants;

        public RestaurantController()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "HotPot Delight", Location = "City Center" },
                new Restaurant { Id = 2, Name = "Tasty Meals", Location = "Downtown" }
            };
        }

        // Get all restaurants
        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(_restaurants);
        }

        // Get a single restaurant by ID
        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            var restaurant = _restaurants.Find(r => r.Id == id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }
    }
}

