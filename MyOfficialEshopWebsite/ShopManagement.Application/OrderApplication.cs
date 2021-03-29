using System.Collections.Generic;
using _0_Framework.Application;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.Order;
using ShopManagement.Domain.Services;

namespace ShopManagement.Application
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository; 
        private readonly IShopInventoryAcl _shopInventoryAcl;

        public OrderApplication(IOrderRepository orderRepository, IAuthHelper authHelper,
            IConfiguration configuration, IShopInventoryAcl shopInventoryAcl)
        {
            _orderRepository = orderRepository;
            _authHelper = authHelper;
            _configuration = configuration; 
            _shopInventoryAcl = shopInventoryAcl;
        }

        public long PlaceOrder(Cart cart, PersonalInfoItemViewModel personalInfo)
        {
            var currentAccountId = _authHelper.CurrentAccountId();

            var personal = new PersonalInfoItem(currentAccountId, personalInfo.Name, personalInfo.Family,
                personalInfo.Company, personalInfo.Country, personalInfo.State, personalInfo.City, personalInfo.Street,
                personalInfo.PostalCode, personalInfo.PlaqueNo, personalInfo.Mobile, personalInfo.Email,
                personalInfo.Description);

            var order = new Order(currentAccountId, cart.PaymentMethod, cart.TotalAmount, cart.DiscountAmount, cart.PayAmount, personal);


            foreach (var cartItem in cart.Items)
            {
                var orderItem = new OrderItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice, cartItem.DiscountRate);

                order.AddItem(orderItem);

            }


            _orderRepository.Create(order);
            _orderRepository.SaveChanges();

            return order.Id;

        }




        public string PaymentSucceeded(long orderId, long refId)
        {
            var order = _orderRepository.Get(orderId);
            order.PaymentSucceeded(refId);
            var symbol = _configuration.GetValue<string>("Symbol");
            var issueTrackingNo = CodeGenerator.Generate(symbol);
            order.SetIssueTrackingNo(issueTrackingNo);

            if (!_shopInventoryAcl.DecreaseFromInventory(order.Items)) return "";

            _orderRepository.SaveChanges();
            return issueTrackingNo;

        }

        public double GetAmountBy(long id)
        {
            return _orderRepository.GetAmountBy(id);
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            return _orderRepository.Search(searchModel);
        }

        public void Cancel(long id)
        {
            var order = _orderRepository.Get(id);
            order.Cancel();
            _orderRepository.SaveChanges();
        }

        public List<OrderItemViewModel> GetItemsBy(long orderId)
        {
            return _orderRepository.GetItemsBy(orderId);
        }

        public PersonalInfoItemViewModel GetPersonalInfoBy(long orderId)
        {
            return _orderRepository.GetPersonalInfoBy(orderId);
        }

        
    }
}
