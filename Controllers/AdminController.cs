using HotPot1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly List<ApplicationUser> _users;

        public AdminController()
        {
            _users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "admin1", FullName = "Admin One" },
                new ApplicationUser { UserName = "user1", FullName = "User One" }
            };
        }

        // Get all users
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Ok(_users);
        }

        // Get a user by username
        [HttpGet("user/{username}")]
        public IActionResult GetUser(string username)
        {
            var user = _users.Find(u => u.UserName == username);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // Delete a user (admin action)
        [HttpDelete("user/{username}")]
        public IActionResult DeleteUser(string username)
        {
            var user = _users.Find(u => u.UserName == username);
            if (user == null)
                return NotFound();

            _users.Remove(user);
            return Ok("User deleted successfully.");
        }
    }
}

