using System;
using _0_Framework.Domain;

namespace DiscountManagement.Domain.CustomerDiscount
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string DiscountReason { get; private set; }

        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string discountReason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            DiscountReason = discountReason;
        }


        public void Edit(long productId, int discountRate, DateTime startDate, DateTime endDate, string discountReason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            DiscountReason = discountReason;
        }
    }
}
