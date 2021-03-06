using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using BlogManagement.Domain.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampshadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            return _blogContext.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryQueryModel
            {
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    ArticlesCount = x.Articles.Count

            }).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategoryBy(string slug)
        {
            return _blogContext.ArticleCategories
                .Select(x => new ArticleCategoryQueryModel
                {
                    Slug = x.Slug,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    Articles = MapArticles(x.Articles),
                    
                    
                }).FirstOrDefault(x => x.Slug == slug);
        }

        private static List<ArticleQueryModel> MapArticles(List<Article> Articles)
        {
            return Articles.Select(x => new ArticleQueryModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi()

            }).ToList();
        }
    }
}
