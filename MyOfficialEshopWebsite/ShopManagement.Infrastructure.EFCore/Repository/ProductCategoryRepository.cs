using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategory;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository :RepositoryBase<long,ProductCategory>,IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _shopContext = context;
        }

        public List<ProductCategoryViewModel> GetProductCategory()
        {
            return _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id=x.Id,
                Name = x.Name
                
            }).ToList();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _shopContext.ProductCategories
                .Select(x => new EditProductCategory()
                {
                    Id = x.Id,
                    Description= x.Description,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    PictureAlt = x.PictureAlt,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    Slug = x.Slug

                })
                .FirstOrDefault(x => x.Id == id);
        }

        public string GetSlugById(long id)
        {
            return _shopContext.ProductCategories.Select(x => new {x.Id, x.Slug}).FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _shopContext.ProductCategories
                .Select(x => new ProductCategoryViewModel()
                {
                    Id = x.Id,
                    Picture = x.PrimaryPicture,
                    Name = x.Name,
                    CreationDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }

       
    }
}
