using _0_Framework.Domain;

namespace ShopManagement.Domain.Slider
{
    public class Slider : EntityBase
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string BtnText { get; private set; }
        public string UrlLink { get; private set; }
        public bool IsRemoved { get; private set; }

        public Slider(string picture, string pictureAlt, string pictureTitle, string heading,
            string title, string text, string btnText, string urlLink)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            UrlLink = urlLink;
            IsRemoved = false;
        }
        public void Edit(string picture, string pictureAlt, string pictureTitle,
            string heading, string title, string text, string btnText, string urlLink)
        {
            if (!string.IsNullOrWhiteSpace(picture))
            {
                Picture = picture;
            }
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            UrlLink = urlLink;

        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }


    }
}
