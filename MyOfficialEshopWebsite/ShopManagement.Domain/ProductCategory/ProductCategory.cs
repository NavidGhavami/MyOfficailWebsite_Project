using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategory
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string PrimaryPicture { get; private set; }
        public string SecondaryPicture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsShow { get; private set; }
        public long? ParentId { get; private set; }

        public List<Product.Product> Products { get; private set; }

        public ProductCategory()
        {
            Products = new List<Product.Product>();
        }

        public ProductCategory(string name, string description, string primaryPicture, string secondaryPicture, string pictureTitle,
            string pictureAlt, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            PrimaryPicture = primaryPicture;
            SecondaryPicture = secondaryPicture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            ParentId = null;
            IsShow = true;
        }

        public void Edit(string name, string description, string primaryPicture, string secondaryPicture, string pictureTitle,
            string pictureAlt, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;

            if (!string.IsNullOrWhiteSpace(primaryPicture))
            {
                PrimaryPicture = primaryPicture;
            }
            if (!string.IsNullOrWhiteSpace(secondaryPicture))
            {
                SecondaryPicture = secondaryPicture;
            }

            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
        public void Remove()
        {
            IsShow = false;
        }
        public void Restore()
        {
            IsShow = true;
        }
    }
}
