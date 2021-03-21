using System.Collections.Generic;

namespace ShopManagement.Application.Contract.Order
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public double TransferAmount { get; set; }
        public double MinimumBuyingAmount { get; set; }
        public bool FreeTransform { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            TransferAmount = 20000;
            MinimumBuyingAmount = 500000;

            Items.Add(cartItem);
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;

            
            



        }


    }
}