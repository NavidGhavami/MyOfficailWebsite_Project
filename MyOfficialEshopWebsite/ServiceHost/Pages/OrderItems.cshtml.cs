using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Order;

namespace ServiceHost.Pages
{
    public class OrderItemsModel : PageModel
    {
        public List<OrderItemViewModel> OrderItems;
        private readonly IOrderApplication _orderApplication;

        public OrderItemsModel( IOrderApplication orderApplication)
        {

            _orderApplication = orderApplication;
        }

        public void OnGetGetItems(long id)
        {
            OrderItems = _orderApplication.GetItemsBy(id);
        }
    }
}
