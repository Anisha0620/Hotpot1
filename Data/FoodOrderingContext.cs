using HotPot1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotPot1.Data
{
    public class FoodOrderingContext : IdentityDbContext<ApplicationUser>
    {
        public FoodOrderingContext(DbContextOptions<FoodOrderingContext> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}

