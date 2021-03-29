using System.Collections.Generic;
using ShopManagement.Domain.Order;

namespace ShopManagement.Domain.Services
{
    public interface IShopInventoryAcl
    {
        bool DecreaseFromInventory(List<OrderItem> items);
    }
}
