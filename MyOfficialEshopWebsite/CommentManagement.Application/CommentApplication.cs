using System.Collections.Generic;
using _0_Framework.Application;
using Comment.Management.Domain.Comment;
using CommentManagement.Application.Contract.Comment;
using Comment = Comment.Management.Domain.Comment.Comment;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var operation = new OperationResult();
            var comment = new global::Comment.Management.Domain.Comment.Comment(command.Name,command.Email,command.Website,command.Message,
                command.OwnerRecordId,command.Type,command.ParentId);

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);

            if (comment==null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            comment.Confirm();
            _commentRepository.SaveChanges();

            return operation.Succedded();
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var comment = _commentRepository.Get(id);

            if (comment == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }

            comment.Cancel();
            _commentRepository.SaveChanges();

            return operation.Succedded();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }

        public List<CommentViewModel> GetAllProductComments(int type)
        {
            return _commentRepository.GetAllProductComments(type);
        }

        public List<CommentViewModel> GetAllArticleComments(int type)
        {
            return _commentRepository.GetAllArticleComments(type);
        }
    }
}
