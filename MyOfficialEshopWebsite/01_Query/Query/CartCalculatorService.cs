using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_Query.Contract.Cart;
using DiscountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.Order;

namespace _01_LampshadeQuery.Query
{
    public class CartCalculatorService : ICartCalculatorService
    {

        private readonly DiscountContext _discountContext;
        private readonly IAuthHelper _authHelper;

        public CartCalculatorService(DiscountContext discountContext, IAuthHelper authHelper)
        {
            _discountContext = discountContext;
            _authHelper = authHelper;
        }

        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var cart = new Cart();

            var colleagueDiscounts = _discountContext.ColleagueDiscounts
                .Where(x => !x.IsRemoved)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();

            var customerDiscounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId })
                .ToList();

            var currentAccountRole = _authHelper.CurrentAccountRole();


            foreach (var item in cartItems)
            {

                if (currentAccountRole == Roles.ColleagueUser)
                {
                    var colleagueDiscount = colleagueDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id);

                    if (colleagueDiscount != null)
                    {
                        item.DiscountRate = colleagueDiscount.DiscountRate;
                    }

                    
                }
                else
                {
                    var customerDiscount = customerDiscounts
                        .FirstOrDefault(x => x.ProductId == item.Id);

                    if (customerDiscount != null)
                    {
                        item.DiscountRate = customerDiscount.DiscountRate;

                    }

                }
                item.DiscountAmount = ((item.TotalItemPrice * item.DiscountRate) / 100);
                item.ItemPayAmount = item.TotalItemPrice - item.DiscountAmount;
                cart.Add(item);
            }


            return cart;
        }
    }

}