using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class WishlistModel : PageModel
    {
        public List<WishlistItem> WishlistItems;
        public string Message;
        public bool IsWishlistEmpty;
        public const string CookieName = "wishlist-items";

        public WishlistModel()
        {
            WishlistItems = new List<WishlistItem>();
        }


        public void OnGet()
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
