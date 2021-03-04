using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        public SelectList ArticleCategories;
        public CreateArticle Command;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication
                .GetArticleCategories(), "Id", "Name");
        }

        public IActionResult OnPost(CreateArticle command)
        {
            var article = _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
