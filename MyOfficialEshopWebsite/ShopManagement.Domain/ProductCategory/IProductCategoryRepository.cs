using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory;

namespace ShopManagement.Domain.ProductCategory
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetProductCategory();
        EditProductCategory GetDetails(long id);
        string GetSlugById(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        
    }
}
