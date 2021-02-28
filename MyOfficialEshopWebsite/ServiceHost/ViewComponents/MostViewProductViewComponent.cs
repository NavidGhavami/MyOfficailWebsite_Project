using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MostViewProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
