using HotPot1.Models;
using HotPot1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotPot1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authService.RegisterAsync(registerModel);
            if (result.Succeeded)
            {
                return Ok("Registration successful!");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _authService.LoginAsync(username, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}

