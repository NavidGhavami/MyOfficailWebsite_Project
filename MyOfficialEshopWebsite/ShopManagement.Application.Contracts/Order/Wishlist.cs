using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class Wishlist
    {
        public List<WishlistItem> Items { get; set; }

        public Wishlist()
        {
            Items = new List<WishlistItem>();
        }

        
    }
}