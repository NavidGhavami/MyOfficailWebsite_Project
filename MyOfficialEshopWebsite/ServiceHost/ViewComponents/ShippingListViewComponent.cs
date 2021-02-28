using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ShippingListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
