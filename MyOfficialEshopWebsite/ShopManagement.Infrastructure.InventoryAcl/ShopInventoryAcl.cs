using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Application.Contract;
using ShopManagement.Domain.Order;
using ShopManagement.Domain.Services;

namespace ShopManagement.Infrastructure.InventoryAcl
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool DecreaseFromInventory(List<OrderItem> items)
        {
            var command = items.Select(orderItem => new DecreaseInventory
                (orderItem.ProductId, orderItem.Count, "خرید مشتری", orderItem.OrderId))
                .ToList();

            return _inventoryApplication.Decrease(command).IsSuccedded;
        }
    }
}
