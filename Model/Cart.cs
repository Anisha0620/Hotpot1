using System.Collections.Generic;

namespace HotPot1.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}

