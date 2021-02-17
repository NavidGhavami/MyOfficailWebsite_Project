using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contract.Slider
{
    public interface ISliderApplication
    {
        OperationResult Create(CreateSlider command);
        OperationResult Edit(EditSlider command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditSlider GetDetails(long id);
        List<SliderViewModel> GetList();
    }
}
