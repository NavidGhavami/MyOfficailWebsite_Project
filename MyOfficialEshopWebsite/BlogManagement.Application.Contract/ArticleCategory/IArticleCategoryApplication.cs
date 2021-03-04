using System.Collections.Generic;
using _0_Framework.Application;

namespace BlogManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetArticleCategories();

    }
}
