using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetProductCategories();
            return View(productCategory);
        }
    }
}
