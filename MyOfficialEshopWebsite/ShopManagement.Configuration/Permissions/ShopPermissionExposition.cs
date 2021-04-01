using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposition : IPermissionExposition
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {"Product", new List<PermissionDto>
                {
                    new PermissionDto(ShopPermission.ListProducts,"لیست محصولات"),
                    new PermissionDto(ShopPermission.SearchProducts,"جستجو محصولات"),
                    new PermissionDto(ShopPermission.CreateProducts,"ایجاد محصول"),
                    new PermissionDto(ShopPermission.EditProducts,"ویرایش محصول"),
                }},
                {"ProductCategory", new List<PermissionDto>
                {
                    new PermissionDto(ShopPermission.ListProductsCategory,"لیست گروه محصولات"),
                    new PermissionDto(ShopPermission.SearchProductsCategory,"جستجو گروه محصولات"),
                    new PermissionDto(ShopPermission.CreateProductsCategory,"ایجاد گروه محصول"),
                    new PermissionDto(ShopPermission.EditProductsCategory,"ویرایش گروه محصول"),
                    new PermissionDto(ShopPermission.IsShowProductCategory,"نمایش گروه محصول"),
                    new PermissionDto(ShopPermission.IsNotShowProductCategory,"عدم نمایش گروه محصول"),
                }},
                {"ProductPicture", new List<PermissionDto>
                {
                    new PermissionDto(ShopPermission.ListProductPicture,"لیست عکس محصولات"),
                    new PermissionDto(ShopPermission.SearchProductPicture,"جستجو عکس محصولات"),
                    new PermissionDto(ShopPermission.CreateProductPicture,"ایجاد عکس محصول"),
                    new PermissionDto(ShopPermission.EditProductPicture,"ویرایش عکس محصول"),
                    new PermissionDto(ShopPermission.ShowProductPicture,"نمایش عکس محصول"),
                }},
                {"Slider", new List<PermissionDto>
                {
                    new PermissionDto(ShopPermission.ListSlider,"لیست اسلایدر"),
                    new PermissionDto(ShopPermission.SearchSlider,"جستجو اسلایدر"),
                    new PermissionDto(ShopPermission.CreateSlider,"ایجاد اسلایدر"),
                    new PermissionDto(ShopPermission.EditSlider,"ویرایش اسلایدر"),
                    new PermissionDto(ShopPermission.ShowSlider,"نمایش اسلایدر"),
                }},
                {"Order", new List<PermissionDto>
                {
                    new PermissionDto(ShopPermission.CancelOrder,"لغو سفارش"),
                    new PermissionDto(ShopPermission.ConfirmOrder,"تایید سفارش"),
                    new PermissionDto(ShopPermission.SearchInCancelOrder,"جستجو در سفارش"),
                }},
            };
        }
    }
}
