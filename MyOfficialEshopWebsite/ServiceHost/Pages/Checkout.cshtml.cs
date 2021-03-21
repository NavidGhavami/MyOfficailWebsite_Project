using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_Query.Contract.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{

    [Authorize]
    public class CheckoutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly ICartService _cartService;
        private readonly IAuthHelper _authHelper;
        public CheckoutModel(ICartCalculatorService cartCalculatorService, ICartService cartService, IAuthHelper authHelper)
        {

            _cartCalculatorService = cartCalculatorService;
            _cartService = cartService;
            _authHelper = authHelper;

            Cart = new Cart();
        }

        public void OnGet()
        {

            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);

            foreach (var item in cartItems)
            {
                item.CalculateTotalItemPrice();
            }

            Cart = _cartCalculatorService.ComputeCart(cartItems);


            if (Cart.TotalAmount < Cart.MinimumBuyingAmount)
            {
                Cart.FreeTransform = false;
                Cart.PayAmount += Cart.TransferAmount;
            }
            else
            {
                Cart.FreeTransform = true;
            }
        }
    }
}

