namespace ShopManagement.Application.Contract.Order
{
    public class OrderSearchModel
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public string IssueTrackingNo { get; set; }
        public bool IsCanceled { get; set; }
        
    }
}
