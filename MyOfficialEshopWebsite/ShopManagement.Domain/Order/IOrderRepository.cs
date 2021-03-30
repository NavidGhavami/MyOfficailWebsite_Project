using System.Collections.Generic;
using _0_Framework.Domain;
using ShopManagement.Application.Contract.Order;

namespace ShopManagement.Domain.Order
{
    public interface IOrderRepository : IRepository<long, Order>
    {
        double GetAmountBy(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        List<OrderItemViewModel> GetItemsBy(long orderId);
        PersonalInfoItemViewModel GetPersonalInfoBy(long orderId);

    }
}
