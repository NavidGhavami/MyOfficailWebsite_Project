using _01_Query.Contract.Slider;
using System.Collections.Generic;
using System.Linq;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class SliderQuery : ISliderQuery
    {
        private readonly ShopContext _shopContext;

        public SliderQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SliderQueryModel> GetSlider()
        {
            return _shopContext.Sliders
                .Where(x => x.IsRemoved == false)
                .Select(x => new SliderQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    BtnText = x.BtnText,
                    Heading = x.Heading,
                    UrlLink = x.UrlLink,
                    Title = x.Title,
                    Text = x.Text

                })
                .ToList();
        }
    }
}
