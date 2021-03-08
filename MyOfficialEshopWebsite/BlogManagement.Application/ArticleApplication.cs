using System.Collections.Generic;
using _0_Framework.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.Article;
using BlogManagement.Domain.ArticleCategory;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader,
            IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();

            if (_articleRepository.Exist(x => x.Title == command.Title))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var path = $"{"Blog"}/{categorySlug}/{slug}";
            var fileName = _fileUploader.Upload(command.Picture, path);

            var article = new Article(command.Title, fileName, command.PictureAlt, command.PictureTitle,
                command.ShortDescription, command.Description, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId, publishDate);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetWithCategory(command.Id);

            if (_articleRepository == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            //if (_articleRepository.Exist(x => x.Title == command.Title && x.Id != command.Id))
            //{
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);
            //}

            var slug = command.Slug.Slugify();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var path = $"{"Blog"}/{article.ArticleCategory.Slug}/{slug}";
            var fileName = _fileUploader.Upload(command.Picture, path);

            article.Edit(command.Title, fileName, command.PictureAlt, command.PictureTitle,
                command.ShortDescription, command.Description, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryId, publishDate);

            _articleRepository.SaveChanges();

            return operation.Succedded();




        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
