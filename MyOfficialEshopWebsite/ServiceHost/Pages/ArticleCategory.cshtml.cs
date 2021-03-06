using System.Collections.Generic;
using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel ArticleCategory;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        public List<ArticleQueryModel> LatestArticle;

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleCategoryModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            ArticleCategory = _articleCategoryQuery.GetArticleCategoryBy(id);
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
            LatestArticle = _articleQuery.LatestArticles();
        }
    }
}
