namespace ShopManagement.Application.Contract.Order
{
    public class OrderSearchModel
    {
        public long OrderId { get; set; }
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public string IssueTrackingNo { get; set; }
        public string Seller { get; set; }
        public bool IsCanceled { get; set; }

        
    }
}
