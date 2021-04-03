using System.Collections.Generic;
using _0_Framework.Application;
using _01_Query.Contract.Order;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class UserDashboardModel : PageModel
    {

        public List<OrderViewModel> Orders;
        public AccountViewModel AccountInfo;
        public EditAccount GetAccountDetails;
        public List<PersonalInfoItemViewModel> PersonalInfo;

        private readonly IOrderQuery _orderQuery;
        private readonly IAuthHelper _authHelper;
        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public UserDashboardModel(IOrderQuery orderQuery, IAuthHelper authHelper, IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderQuery = orderQuery;
            _authHelper = authHelper;
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {

            var account = _authHelper.CurrentAccountId();

            Orders = _orderQuery.GetOrderBy(account);
            AccountInfo = _orderQuery.GetAccountInformation(account);
            PersonalInfo = _orderQuery.GetPersonalInfoItemBy(account);
            GetAccountDetails = _accountApplication.GetDetails(account);

        }

        public IActionResult OnGetGetItems(long id)
        {
            var orderItem = _orderApplication.GetItemsBy(id);
            return RedirectToPage("/OrderItems", orderItem);
        }

        public IActionResult OnPostEdit(EditAccount command)
        {
            GetAccountDetails = _accountApplication.GetDetails(command.Id);

            command.Id = GetAccountDetails.Id;
            command.RoleId = GetAccountDetails.RoleId;

            var account = _accountApplication.Edit(command);

            return RedirectToPage("/UserDashboard", account);
        }

        public IActionResult OnPostChangePassword(ChangePassword command)
        {
            GetAccountDetails = _accountApplication.GetDetails(command.Id);

            command.Id = GetAccountDetails.Id;
            
            var password = _accountApplication.ChangePassword(command);

            return RedirectToPage("/UserDashboard", password);
        }
    }
}
