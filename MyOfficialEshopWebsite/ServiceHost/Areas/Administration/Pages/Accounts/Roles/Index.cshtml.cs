using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Roles
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }

        public List<RoleViewModel> Role;
        private readonly IRoleApplication _roleApplication;


        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }


        public void OnGet(AccountSearchModel searchModel)
        {
            Role = _roleApplication.List();
        }
    }
}
