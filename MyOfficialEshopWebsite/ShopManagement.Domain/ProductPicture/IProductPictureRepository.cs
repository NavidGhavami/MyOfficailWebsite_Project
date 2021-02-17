using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductPicture;

namespace ShopManagement.Domain.ProductPicture
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        ProductPicture GetWithProductAndCategory(long id);
    }
}
