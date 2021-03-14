using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace InventoryManagement.Configuration.Permissions
{
    public class InventoryPermissionExposition : IPermissionExposition
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {"Inventory", new List<PermissionDto>

                {
                    new PermissionDto(InventoryPermission.ListInventory,"لیست انبار"),
                    new PermissionDto(InventoryPermission.SearchInventory,"جستجو انبار"),
                    new PermissionDto(InventoryPermission.CreateInventory,"ایجاد انبار"),
                    new PermissionDto(InventoryPermission.EditInventory,"ویرایش انبار"),
                    new PermissionDto(InventoryPermission.IncreaseInventory,"افزایش موجودی انبار"),
                    new PermissionDto(InventoryPermission.DecreaseInventory,"کاهش موجودی انبار"),
                    new PermissionDto(InventoryPermission.CycleInventory,"مشاهده گردش انبار"),
                }},

            };
        }
    }
}
