using System;
using System.Collections.Generic;
using System.Text;
using _0_Framework.Domain;
using ShopManagement.Application.Contract.Slider;

namespace ShopManagement.Domain.Slider
{
    public interface ISliderRepository : IRepository<long, Slider>
    {
        EditSlider GetDetails(long id);
        List<SliderViewModel> GetList();
    }
}
