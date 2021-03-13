using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Roles
{
    public class EditModel : PageModel
    {
        public EditRole Command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposition> _exposition;


        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposition> exposition)
        {
            _roleApplication = roleApplication;
            _exposition = exposition;
        }

        public void OnGet(long id)
        {
            Command = _roleApplication.GetDetails(id);
            var permissions = new List<PermissionDto>();
            foreach (var exposition in _exposition)
            {
                var exposedPermissions = exposition.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    permissions.AddRange(value);
                    var group = new SelectListGroup
                    {
                        Name = key
                    };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                        {
                            item.Selected = true;
                        }
                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRole command)
        {
            var result = _roleApplication.EditRole(command);
            return RedirectToPage("Index");
        }
    }
}
