using System.Collections.Generic;
using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.Product;
using ShopManagement.Domain.ProductPicture;

namespace ShopManagement.Application
{
    public class ProductPictureApplication:IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader,IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            //if (_productPictureRepository.Exist(x=> x.Id == command.ProductId))
            //{
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            //}

            var product = _productRepository.GetProductWithCategory(command.ProductId);

            var picturePath = $"{"Shop"}/{"ProductCategory"}/{product.Category.Slug}/{product.Slug}/{command.PictureAlt}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            var productPicture = new ProductPicture(command.ProductId,fileName,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);

            //if (productPicture==null)
            //{
            //    return operation.Failed(ApplicationMessages.RecordNotFound);
            //}
            //if (_productPictureRepository.Exist(x=> 
            //    x.ProductId == command.ProductId
            //    && x.Id!= command.Id))
            //{
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            //}
            var product = _productRepository.GetProductWithCategory(command.ProductId);

            var picturePath = $"{"Shop"}/{"ProductCategory"}/{product.Category.Slug}/{product.Slug}/{command.PictureAlt}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            productPicture.Edit(command.ProductId, fileName, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();

            return operation.Succedded();

        }
        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

          

            productPicture.Remove();
            _productPictureRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }



            productPicture.Restore();
            _productPictureRepository.SaveChanges();

            return operation.Succedded();
        }

        
    }
}
