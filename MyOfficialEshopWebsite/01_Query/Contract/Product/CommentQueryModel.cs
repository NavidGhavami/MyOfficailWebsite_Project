namespace _01_Query.Contract.Product
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public string CreationDate { get; set; }
        public long ParentId { get; set; }
        public string ParentName { get; set; }
        public long OwnerRecordId { get; set; }

    }
}