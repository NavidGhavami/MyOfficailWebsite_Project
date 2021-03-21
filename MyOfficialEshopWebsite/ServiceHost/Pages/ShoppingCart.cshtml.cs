using System.Collections.Generic;
using System.Linq;
using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public List<CartItem> CartItems;
        public string Message;
        public bool IsCartEmpty;
        public const string CookieName = "cart-items";

        private readonly IProductQuery _productQuery;

        public ShoppingCartModel(IProductQuery productQuery)
        {
            CartItems = new List<CartItem>();
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            if (value == "[]")
            {
                IsCartEmpty = true;
                Message = "سبد خرید شما خالی می باشد.";
            }
            else
            {
                IsCartEmpty = false;
            }
            var cartItems = serializer.Deserialize<List<CartItem>>(value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);
        }


        public IActionResult OnGetGotoPersonalInfo()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
            }

            CartItems = _productQuery.CheckInventoryStatus(cartItems);
            return RedirectToPage(CartItems.Any(x => !x.IsInStock) ? "/ShoppingCart" : "/PersonalInfo");
        }
    }
}
