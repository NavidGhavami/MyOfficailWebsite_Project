using System.Collections.Generic;

namespace _01_Query.Contract.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        List<ArticleCategoryQueryModel> GetArticleCategories();
        ArticleCategoryQueryModel GetArticleCategoryBy(string slug);
    }
}
