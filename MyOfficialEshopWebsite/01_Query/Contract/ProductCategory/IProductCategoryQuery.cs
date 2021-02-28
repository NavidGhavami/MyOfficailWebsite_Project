using System.Collections.Generic;

namespace _01_Query.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesMiddleBanner();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsCount();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInMostSellProduct();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInBestChoice();
    }
}
