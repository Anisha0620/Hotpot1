using HotPot1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotPot1.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            var user = new ApplicationUser
            {
                UserName = registerModel.Username,
                FullName = registerModel.FullName
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            return result;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, password);
                if (result)
                {
                    // Generate JWT token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.UserName) }),
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"]
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);  // Return actual JWT
                }
            }

            return null;  // Return null if authentication fails
        }
    }
}

