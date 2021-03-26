using System.Collections.Generic;
using _0_Framework.Domain;

namespace ShopManagement.Domain.Order
{
    public class Order : EntityBase
    {
        public long AccountId { get; private set; }
        public int PaymentMethod { get; private set; }
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsCanceled { get; private set; }
        public long RefId { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public PersonalInfoItem PersonalInfoItem { get; private set; }

        public Order()
        {
        }

        public Order(long accountId, int paymentMethod, double totalAmount, double discountAmount, double payAmount,PersonalInfoItem personalInfo)
        {
            AccountId = accountId;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            PaymentMethod = paymentMethod;
            IsPaid = false;
            IsCanceled = false;
            RefId = 0;
            Items = new List<OrderItem>();
            PersonalInfoItem = personalInfo;

        }

        public void PaymentSucceeded(long refId)
        {
            IsPaid = true;
            IsCanceled = false;
            if (refId != 0)
            {
                RefId = refId;
            }
        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }

        public void Cancel()
        {
            IsPaid = false;
            IsCanceled = true;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        
    }
}
