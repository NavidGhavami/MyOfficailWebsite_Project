using System.Collections.Generic;
using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Areas.Administration.Pages.Shop.Orders
{
    public class IndexModel : PageModel
    {
        public OrderSearchModel SearchModel;
        public List<OrderViewModel> Orders;
        public SelectList Accounts;


        private readonly IOrderApplication _orderApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IOrderApplication orderApplication, IAccountApplication accountApplication)
        {
            _orderApplication = orderApplication;
            _accountApplication = accountApplication;
        }



        public void OnGet(OrderSearchModel searchModel)
        {
            Accounts = new SelectList(_accountApplication.GetAccounts(), "Id", "FullName");
            Orders = _orderApplication.Search(searchModel);

        }

        public IActionResult OnGetConfirm(long id)
        {
            _orderApplication.PaymentSucceeded(id, 0);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetCancel(long id)
        {
            _orderApplication.Cancel(id);
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetGetItems(long id)
        {
            var items = _orderApplication.GetItemsBy(id);
            return Partial("Items", items);
        }

        public IActionResult OnGetGetPersonalInfo(long id)
        {
            var personalInfo = _orderApplication.GetPersonalInfoBy(id);
            return Partial("PersonalInfo", personalInfo);
        }

    }
}
