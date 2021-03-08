using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.Article;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;
        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.CategoryId,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PublishDate = x.PublishDate.ToFarsi(),
                Slug = x.Slug


            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _blogContext.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Picture = x.Picture,
                    CategoryId = x.CategoryId,
                    Category = x.ArticleCategory.Name,
                    ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + "...",
                    PublishDate = x.PublishDate.ToFarsi(),

                });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
            {
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            }
            if (searchModel.CategoryId != 0)
            {
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public Article GetWithCategory(long id)
        {
            return _blogContext.Articles
                .Include(x => x.ArticleCategory)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
