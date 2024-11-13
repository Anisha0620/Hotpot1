using Microsoft.AspNetCore.Identity;

namespace HotPot1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}



