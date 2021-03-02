using System.Collections.Generic;
using _0_Framework.Domain;
using CommentManagement.Application.Contract.Comment;

namespace Comment.Management.Domain.Comment
{
    public interface ICommentRepository:IRepository<long , Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
        List<CommentViewModel> GetAllProductComments(int type);
        List<CommentViewModel> GetAllArticleComments(int type);
    }
}
