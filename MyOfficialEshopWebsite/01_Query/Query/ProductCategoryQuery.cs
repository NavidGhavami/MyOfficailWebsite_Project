using System.Collections.Generic;
using System.Linq;
using _01_Query.Contract.ProductCategory;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories
                .Where(x => x.IsShow == true)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PrimaryPicture = x.PrimaryPicture,
                    SecondaryPicture = x.SecondaryPicture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug

                }).Take(6).ToList();
        }
    }
}
