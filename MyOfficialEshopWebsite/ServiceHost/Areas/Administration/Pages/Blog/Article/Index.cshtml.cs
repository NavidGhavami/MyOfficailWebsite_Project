using System.Collections.Generic;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel;
        public List<ArticleViewModel> Article;
        public SelectList ArticleCategory;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            ArticleCategory = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            Article = _articleApplication.Search(searchModel);

        }
    }
}
