using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Newtonsoft.Json;

namespace _01_Query.Contract.Product
{
    public class CommentQueryModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public string CreationDate { get; set; }
        public long ParentId { get; set; }
        public string ParentName { get; set; }
        public long OwnerRecordId { get; set; }

    }
}