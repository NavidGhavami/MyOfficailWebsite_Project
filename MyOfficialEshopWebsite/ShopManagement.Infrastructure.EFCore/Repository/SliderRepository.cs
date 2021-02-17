using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.Slider;
using ShopManagement.Domain.Slider;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SliderRepository : RepositoryBase<long, Slider>, ISliderRepository
    {
        private readonly ShopContext _context;

        public SliderRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlider GetDetails(long id)
        {
            return _context.Sliders.Select(x => new EditSlider
            {
                Id = x.Id,
                //Picture = x.Picture,
                BtnText = x.BtnText,
                Heading = x.Heading,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Text = x.Text,
                Title = x.Title,
                UrlLink = x.UrlLink

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<SliderViewModel> GetList()
        {
            return _context.Sliders.Select(x => new SliderViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Heading = x.Heading,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi()


            }).OrderByDescending(x => x.Id).ToList();
        }


    }
}
