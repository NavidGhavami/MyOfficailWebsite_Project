using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MostViewProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public MostViewProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var product = _productQuery.GetProductsByMaximumViewList();
            return View(product);
        }
    }
}
