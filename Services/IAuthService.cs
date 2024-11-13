using HotPot1.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HotPot1.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterModel registerModel);  // Updated
        Task<string> LoginAsync(string username, string password);
    }
}

