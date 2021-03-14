using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace DiscountManagement.Configuration.Permissions
{
    public class DiscountPermissionExposition : IPermissionExposition
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {"CustomerDiscount", new List<PermissionDto>
                {
                    new PermissionDto(DiscountPermission.ListCustomerDiscount,"لیست تخفیفات مشتریان"),
                    new PermissionDto(DiscountPermission.SearchCustomerDiscount,"جستجو تخفیفات مشتریان"),
                    new PermissionDto(DiscountPermission.CreateCustomerDiscount,"ایجاد تخفیف مشتری"),
                    new PermissionDto(DiscountPermission.EditCustomerDiscount,"ویرایش تخفیف مشتری"),
                }},
                {"ColleagueDiscount", new List<PermissionDto>
                {
                    new PermissionDto(DiscountPermission.ListColleagueDiscount,"لیست تخفیفات همکاران"),
                    new PermissionDto(DiscountPermission.SearchColleagueDiscount,"جستجو تخفیفات همکاران"),
                    new PermissionDto(DiscountPermission.CreateColleagueDiscount,"ایجاد تخفیف همکاری"),
                    new PermissionDto(DiscountPermission.EditColleagueDiscount,"ویرایش تخفیف همکاری"),
                    new PermissionDto(DiscountPermission.AccessColleagueDiscount,"دادن تخفیف همکاری"),
                }},
            };
        }
    }
}
