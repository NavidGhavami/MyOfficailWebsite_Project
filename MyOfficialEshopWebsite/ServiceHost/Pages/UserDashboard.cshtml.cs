using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_Query.Contract.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class UserDashboardModel : PageModel
    {

        public List<OrderViewModel> Orders;
        public List<PersonalInfoItemViewModel> PersonalInfo;

        private readonly IOrderQuery _orderQuery;
        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;

        public UserDashboardModel(IOrderQuery orderQuery, IAuthHelper authHelper, IOrderApplication orderApplication)
        {
            _orderQuery = orderQuery;
            _authHelper = authHelper;
            _orderApplication = orderApplication;
        }

        public void OnGet()
        {
            
            var account = _authHelper.CurrentAccountId();
            

            Orders = _orderQuery.GetOrderBy(account);
            PersonalInfo = _orderQuery.GetPersonalInfoItemBy(account);

        }
        public IActionResult OnGetGetItems(long id)
        {
            var orderItem = _orderApplication.GetItemsBy(id);
            return RedirectToPage("/OrderItems", orderItem);
        }
    }
}
