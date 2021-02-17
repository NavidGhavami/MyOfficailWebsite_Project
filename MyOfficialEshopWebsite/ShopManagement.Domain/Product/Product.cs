using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.Product
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Seller { get; set; }
        public string PrimaryPicture { get; private set; }
        public string SecondaryPicture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategory.ProductCategory Category { get; set; }

        // public List<ProductPicture.ProductPicture> ProductPictures { get; private set; }


        public Product(string name, string code, string shortDescription,
            string description, string seller, string primaryPicture, string secondaryPicture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Seller = seller;
            PrimaryPicture = primaryPicture;
            SecondaryPicture = secondaryPicture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;

        }
        public void Edit(string name, string code, string shortDescription,
            string description, string seller, string primaryPicture, string secondaryPicture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Seller = seller;

            if (!string.IsNullOrWhiteSpace(primaryPicture))
            {
                PrimaryPicture = primaryPicture;
            }
            if (!string.IsNullOrWhiteSpace(secondaryPicture))
            {
                SecondaryPicture = secondaryPicture;
            }

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;


        }
    }
}
