using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_Query.Contract.Cart;
using _01_Query.Contract.Product;
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

        private readonly IAuthHelper _authHelper;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IOrderApplication _orderApplication;
        private readonly ICartCalculatorService _cartCalculatorService;
        public CheckoutModel(ICartCalculatorService calculatorService, ICartService cartService,
            IProductQuery productQuery, IOrderApplication orderApplication, IZarinPalFactory zarinPalFactory, IAuthHelper authHelper)
        {
            _cartCalculatorService = calculatorService;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderApplication = orderApplication;
            _zarinPalFactory = zarinPalFactory;
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


            if (Cart.TotalAmount <= Cart.MinimumBuyingAmount)
            {
                Cart.FreeTransform = false;
                Cart.PayAmount += Cart.TransferAmount;
            }
            else
            {
                Cart.FreeTransform = true;
            }

            _cartService.Set(Cart);
        }
        public IActionResult OnPostPay(int paymentMethod, PersonalInfoItemViewModel personalInfo)
        {
            var cart = _cartService.Get();
            cart.SetPaymentMethod(paymentMethod);


            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
            {
                return RedirectToPage("/ShoppingCart");
            }

            var orderId = _orderApplication.PlaceOrder(cart, personalInfo);
            var accountMobile = _authHelper.CurrentAccountInfo().Mobile;
            var accountUserName = _authHelper.CurrentAccountInfo().Username;


            if (paymentMethod == 1)
            {
                var paymentResult = new PaymentResult();
                var creationDate = DateTime.Now.ToFarsi();

                Response.Cookies.Delete(CookieName);

                return RedirectToPage("/PaymentResult", paymentResult.Succeeded(
                    "سفارش شما ثبت شد. پس از تماس کارشناسان ما و پرداخت وجه سفارش ارسال خواهد شد.", null, creationDate));
                

            }
            else
            {

                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(

                    cart.PayAmount.ToString(CultureInfo.InvariantCulture),
                    accountMobile,
                    accountUserName,
                    "خرید از فروشگاه هنری",
                    orderId
                  
                );

                return Redirect($"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");

            }
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            var orderAmount = _orderApplication.GetAmountBy(oId);
            var verificationResponse = _zarinPalFactory.CreateVerificationRequest(authority, orderAmount.ToString(CultureInfo.InvariantCulture));
            var result = new PaymentResult();

            if (status == "OK" && verificationResponse.Status == 100)
            {
                var issueTrackingNo = _orderApplication.PaymentSucceeded(oId, verificationResponse.RefID);
                var creationDate = DateTime.Now.ToFarsiFull();
                Response.Cookies.Delete(CookieName);
                result = result.Succeeded("پرداخت با موفقیت انجام شد.", issueTrackingNo, creationDate);

                return RedirectToPage("/PaymentResult", result);

            }
            else
            {
                result = result.Failed("پرداخت با موفقیت انجام نگردید. درصورت کسر وجه از حساب، مبلغ تا 24 ساعت دیگر به حساب شما باز می گردد.");

                return RedirectToPage("/PaymentResult", result);
            }
        }
    }
}

