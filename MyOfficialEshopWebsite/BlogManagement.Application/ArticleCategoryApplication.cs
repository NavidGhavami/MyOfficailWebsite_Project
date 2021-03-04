using System.Collections.Generic;
using _0_Framework.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategory;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();

            if (_articleCategoryRepository.Exist(x => x.Name == command.Name))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }


            var slug = command.Slug.Slugify();
            var path = $"{"Blog"}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            var articleCategory = new ArticleCategory(command.Name, pictureName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.ShowOrder,
                 slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);


            if (_articleCategoryRepository == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

           
            var slug = command.Slug.Slugify();
            var path = $"{"Blog"}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);

            articleCategory.Edit(command.Name, pictureName, command.PictureAlt,
                command.PictureTitle, command.ShortDescription, command.Description, command.ShowOrder,
                slug, command.Keywords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }
    }
}
