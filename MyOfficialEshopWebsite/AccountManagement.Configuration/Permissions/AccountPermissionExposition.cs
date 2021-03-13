using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace AccountManagement.Configuration.Permissions
{
    public class AccountPermissionExposition:IPermissionExposition
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {"Account", new List<PermissionDto>
                {
                    new PermissionDto(AccountPermission.ListAccount,"لیست کاربران"),
                    new PermissionDto(AccountPermission.SearchAccount,"جستجو کاربران"),
                    new PermissionDto(AccountPermission.CreateAccount,"ایجاد کاربر"),
                    new PermissionDto(AccountPermission.EditAccount,"ویرایش کاربر"),
                    new PermissionDto(AccountPermission.ChangePasswordAccount,"تغییر کلمه عبور کاربر"),
                }},
                {"Role", new List<PermissionDto>
                {
                    new PermissionDto(AccountPermission.CreateRole,"ایجاد نقش"),
                    new PermissionDto(AccountPermission.EditRole,"ویرایش نقش"),
                }},
            };
        }
    }
}
