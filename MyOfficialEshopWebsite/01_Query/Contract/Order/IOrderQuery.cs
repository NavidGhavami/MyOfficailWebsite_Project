using System.Collections.Generic;
using AccountManagement.Application.Contract.Account;
using ShopManagement.Application.Contract.Order;

namespace _01_Query.Contract.Order
{
    public interface IOrderQuery
    {
        List<OrderViewModel> GetOrderBy(long accountId);
        List<PersonalInfoItemViewModel> GetPersonalInfoItemBy(long accountId);
        AccountViewModel GetAccountInformation(long accountId);



    }
}
