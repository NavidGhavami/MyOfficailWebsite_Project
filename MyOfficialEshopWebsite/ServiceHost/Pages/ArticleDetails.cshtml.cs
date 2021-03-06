using System.Collections.Generic;
using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleCategoryQueryModel> ArticleCategory;
        public List<ArticleQueryModel> LatestArticle;

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentApplication _commentApplication;


        public ArticleDetailsModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            ArticleCategory = _articleCategoryQuery.GetArticleCategories();
            Article = _articleQuery.GetArticleDetails(id);
            LatestArticle = _articleQuery.LatestArticles();
        }
        public IActionResult OnPost(AddComment command, string articleSlug)
        {
            command.Type = CommentTypes.Article;
            var result = _commentApplication.Add(command);
            return RedirectToPage("./ArticleDetails", new { id = articleSlug });
        }
    }
}
