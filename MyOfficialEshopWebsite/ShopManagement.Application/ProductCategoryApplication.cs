using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategory;


namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public List<ProductCategoryViewModel> GetProductCategory()
        {
            return _productCategoryRepository.GetProductCategory();
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x=>x.Name==command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var picturePath = $"{"Shop"}/{"ProductCategory"}/{slug}";

            var primaryFilename = _fileUploader.Upload(command.PrimaryPicture, picturePath);
            var secondaryFilename = _fileUploader.Upload(command.SecondaryPicture, picturePath);

            var productCategory = new ProductCategory(command.Name, command.Description, primaryFilename, secondaryFilename,
                command.PictureTitle, command.PictureAlt, command.Keywords, command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();

            return operation.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            }
            var slug = command.Slug.Slugify();
            var picturePath = $"{"Shop"}/{"ProductCategory"}/{slug}";

            var primaryFilename = _fileUploader.Upload(command.PrimaryPicture, picturePath);
            var secondaryFilename = _fileUploader.Upload(command.SecondaryPicture, picturePath);

            productCategory.Edit(command.Name, command.Description, primaryFilename, secondaryFilename, command.PictureTitle,
                command.PictureAlt, command.Keywords, command.MetaDescription, slug);

            _productCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            return _productCategoryRepository.Search(search);
        }
    }
}
