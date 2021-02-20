namespace _01_Query.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PrimaryPicture { get; set; }
        public string SecondaryPicture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public string Slug { get; set; }
        public bool IsShow { get; set; }
    }
}
