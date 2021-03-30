using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string AccountFullname { get; set; }
        public int PaymentMethodId { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public long RefId { get; set; }
        public string IssueTrackingNo { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodText { get; set; }
        public string CreationDate { get; set; }
        public OrderItemViewModel Items { get; set; }





    }
}