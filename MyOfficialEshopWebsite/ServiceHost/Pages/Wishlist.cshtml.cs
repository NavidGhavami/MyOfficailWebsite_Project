using System.Collections.Generic;
using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.Product;

namespace ServiceHost.Pages
{
    public class WishlistModel : PageModel
    {
        public List<WishlistItem> WishlistItems;
        public string Message;
        public bool IsWishlistEmpty;
        public const string CookieName = "wishlist-items";


        public WishlistModel(IProductQuery productQuery)
        {
            WishlistItems = new List<WishlistItem>();
        }


        public void OnGet(string id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            WishlistItems = serializer.Deserialize<List<WishlistItem>>(value);
            if (value == "[]")
            {
                IsWishlistEmpty = true;
                Message = "لیست علاقه مندی های شما خالی می باشد.";
            }
            else
            {
                IsWishlistEmpty = false;
            }


        }
    }
}
