using _01_Query.Contract.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var article = _articleQuery.LatestArticles();
            return View(article);
        }
    }
}
