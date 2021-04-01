using System.Collections.Generic;

namespace _01_Query.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesMiddleBanner();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
        ProductCategoryQueryModel GetProductCategoriesWithProductsBy(string slug);
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsCount();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInMostSellProduct();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInBestChoice();
        int ProductCategoryCount();

    }
}
