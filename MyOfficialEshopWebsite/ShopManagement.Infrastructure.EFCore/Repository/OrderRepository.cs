using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Domain.Order;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class OrderRepository : RepositoryBase<long, Order>, IOrderRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;
        public OrderRepository(ShopContext shopContext, AccountContext accountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public double GetAmountBy(long id)
        {
            var order = _shopContext.Orders.Select(x => new { x.Id, x.PayAmount }).FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                return order.PayAmount;
            }

            return 0;
        }

        public List<OrderViewModel> Search(OrderSearchModel searchModel)
        {
            var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.FullName });
            var query = _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                AccountId = x.AccountId,
                DiscountAmount = x.DiscountAmount,
                IsCanceled = x.IsCanceled,
                IsPaid = x.IsPaid,
                IssueTrackingNo = x.IssueTrackingNo,
                PayAmount = x.PayAmount,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi(),


            });

            query = query.Where(x => x.IsCanceled == searchModel.IsCanceled);

            if (searchModel.AccountId > 0)
            {
                query = query.Where(x => x.AccountId == searchModel.AccountId);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.AccountName))
            {
                var ords = query.OrderByDescending(x => x.Id).ToList();

                foreach (var order in ords)
                {
                    order.AccountFullname = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.FullName;
                }
                query = query.Where(x => x.AccountFullname.Contains(searchModel.AccountName));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.IssueTrackingNo))
            {
                query = query.Where(x => x.IssueTrackingNo.Contains(searchModel.IssueTrackingNo));
            }

            var orders = query.OrderByDescending(x => x.Id).ToList();

            foreach (var order in orders)
            {
                order.AccountFullname = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.FullName;
            }

            return orders;

        }

        public List<OrderItemViewModel> GetItemsBy(long orderId)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var order = _shopContext.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
            {
                return new List<OrderItemViewModel>();
            }

            var items = order.Items.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,


            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }

        public PersonalInfoItemViewModel GetPersonalInfoBy(long orderId)
        {
            var order = _shopContext.Orders
                .Include(x => x.PersonalInfoItem)
                .FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                return new PersonalInfoItemViewModel();
            }

            var personalInfo = new PersonalInfoItemViewModel 
            {
                Id = order.PersonalInfoItem.Id,
                AccountId = order.PersonalInfoItem.AccountId,
                Name = order.PersonalInfoItem.Name,
                Family = order.PersonalInfoItem.Family,
                Company = order.PersonalInfoItem.Company,
                Country = order.PersonalInfoItem.Country,
                State = order.PersonalInfoItem.State,
                City = order.PersonalInfoItem.City,
                Street = order.PersonalInfoItem.Street,
                PostalCode = order.PersonalInfoItem.PostalCode,
                PlaqueNo = order.PersonalInfoItem.PlaqueNo,
                Mobile = order.PersonalInfoItem.Mobile,
                Email = order.PersonalInfoItem.Email,
                Description = order.PersonalInfoItem.Description

            };



            return personalInfo;
        }
    }
}
