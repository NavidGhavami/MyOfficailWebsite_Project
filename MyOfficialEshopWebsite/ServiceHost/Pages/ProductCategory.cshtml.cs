using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public int PageId;
        public int PageCount;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id, int pageId = 1)
        {

            var count = _productCategoryQuery.ProductCategoryCount();
            ProductCategory = _productCategoryQuery.GetProductCategoriesWithProductsBy(id);

            PageId = pageId;
            PageCount = count / 60;


            

        }

    }
}
