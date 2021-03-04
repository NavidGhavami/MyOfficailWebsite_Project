using System;
using _0_Framework.Domain;

namespace BlogManagement.Domain.Article
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public DateTime PublishDate { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory.ArticleCategory ArticleCategory { get; set; }


        public Article(string title, string picture, string pictureAlt, string pictureTitle, string shortDescription,
            string description, string slug, string keywords, string metaDescription, string canonicalAddress,
            long categoryId, DateTime publishDate)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;
        }

        public void Edit(string title, string picture, string pictureAlt, string pictureTitle, string shortDescription,
            string description, string slug, string keywords, string metaDescription, string canonicalAddress,
            long categoryId, DateTime publishDate)
        {
            Title = title;
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
            PublishDate = publishDate;

        }
    }
}
