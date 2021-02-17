using System.Collections.Generic;
using _0_Framework.Application;


namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        List<ProductCategoryViewModel> GetProductCategory();
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);

    }
}
