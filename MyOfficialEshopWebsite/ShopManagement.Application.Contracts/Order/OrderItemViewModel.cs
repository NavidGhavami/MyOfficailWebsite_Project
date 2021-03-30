using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long AccountId { get; set; }
        public string Product { get; set; }
        public string Seller { get; set; }
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountRate { get; set; }
        public long OrderId { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
