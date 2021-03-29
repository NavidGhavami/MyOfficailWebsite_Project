using System.Collections.Generic;
using _0_Framework.Application;

namespace ShopManagement.Application.Contract.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart, PersonalInfoItemViewModel personalInfo);
        string PaymentSucceeded(long orderId, long refId);
        double GetAmountBy(long id);
        List<OrderViewModel> Search(OrderSearchModel searchModel);
        void Cancel(long id);
        List<OrderItemViewModel> GetItemsBy(long orderId);
        PersonalInfoItemViewModel GetPersonalInfoBy(long orderId);



    }
}
