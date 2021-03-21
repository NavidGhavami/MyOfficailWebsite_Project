namespace ShopManagement.Application.Contract.Order
{
    public class WishlistItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double DoublePrice { get; set; }
        public string Picture { get; set; }
        public string Slug { get; set; }
        public int Count { get; set; }
        public double TotalItemPrice { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double ItemPayAmount { get; set; }
        public bool IsInStock { get; set; }

        public WishlistItem()
        {
            TotalItemPrice = UnitPrice * Count;
        }

        public void CalculateTotalItemPrice()
        {
            TotalItemPrice = UnitPrice * Count;
        }
    }
}
