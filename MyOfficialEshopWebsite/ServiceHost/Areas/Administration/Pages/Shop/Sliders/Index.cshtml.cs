using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Slider;

namespace ServiceHost.Areas.Administration.Pages.Shop.Sliders
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public List<SliderViewModel> slider;

        private readonly ISliderApplication _sliderApplication;

        public IndexModel(ISliderApplication sliderApplication)
        {
            _sliderApplication = sliderApplication;

        }


        public void OnGet()
        {

            slider = _sliderApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlider();
            return Partial("./Create", command);

        }

        public JsonResult OnPostCreate(CreateSlider command)
        {
            var result = _sliderApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide = _sliderApplication.GetDetails(id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlider command)
        {
            var result = _sliderApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _sliderApplication.Remove(id);

            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _sliderApplication.Restore(id);
            if (result.IsSuccedded)
            {
                return RedirectToPage("./Index");
            }

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
