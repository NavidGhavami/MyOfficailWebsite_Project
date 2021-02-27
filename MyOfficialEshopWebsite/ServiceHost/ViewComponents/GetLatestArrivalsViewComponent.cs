using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Query.Contract.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace ServiceHost.ViewComponents
{
    public class GetLatestArrivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public GetLatestArrivalsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var latestArrivals = _productQuery.GetLatestArrivals();
            return View(latestArrivals);
        }
    }
}
