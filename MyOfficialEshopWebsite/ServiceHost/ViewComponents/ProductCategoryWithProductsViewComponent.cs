using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWithProductsViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWithProductsViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetProductCategoriesWithProducts();
            return View(productCategory);
        }
    }
}
