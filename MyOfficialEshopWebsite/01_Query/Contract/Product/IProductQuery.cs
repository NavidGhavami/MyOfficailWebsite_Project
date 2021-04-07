using System.Collections.Generic;
using ShopManagement.Application.Contract.Order;

namespace _01_Query.Contract.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> GetProductsByMaximumViewList();
        List<ProductQueryModel> RightSidebarGetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        ProductQueryModel GetProductDetails(string slug);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);

    }
}
