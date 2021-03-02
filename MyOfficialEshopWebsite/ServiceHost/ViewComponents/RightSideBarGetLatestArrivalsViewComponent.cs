using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    
    public class RightSideBarGetLatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public RightSideBarGetLatestArrivalsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var product = _productQuery.RightSidebarGetLatestArrivals();
            return View(product);
        }
    }
}
