using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contract.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult EditProductView(EditProductView command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
        OperationResult ISBestChoice(long id);
        OperationResult ISNotBestChoice(long id);
    }
}
