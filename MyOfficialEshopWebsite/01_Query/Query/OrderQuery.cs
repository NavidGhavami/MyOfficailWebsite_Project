using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_Query.Contract.Order;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;

        public OrderQuery(ShopContext shopContext, AccountContext accountContext)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public List<OrderViewModel> GetOrderBy(long accountId)
        {
            var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.FullName }).ToList();

            var query = _shopContext.Orders
                .Where(x => x.AccountId == accountId)
                .Select(x => new OrderViewModel
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
                    PaymentMethod = x.PaymentMethod,
                    PaymentMethodId = x.PaymentMethod,
                    CreationDate = x.CreationDate.ToFarsi(),


                });

            var orders = query.OrderByDescending(x => x.Id);
            foreach (var order in orders)
            {
                order.AccountFullname = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.FullName;
                order.PaymentMethodText = PaymentMethod.GetBy(order.PaymentMethodId).Name;
            }

            return orders.ToList();
        }

        public List<PersonalInfoItemViewModel> GetPersonalInfoItemBy(long accountId)
        {
            var info = _shopContext.Orders
                .Include(x => x.PersonalInfoItem)
                .Where(x => x.AccountId == accountId)
                .Select(x => new PersonalInfoItemViewModel
                {
                    Id = x.Id,
                    AccountId = x.AccountId,
                    OrderId = x.PersonalInfoItem.OrderId,
                    Name = x.PersonalInfoItem.Name,
                    Family = x.PersonalInfoItem.Family,
                    Company = x.PersonalInfoItem.Company,
                    Country = x.PersonalInfoItem.Country,
                    State = x.PersonalInfoItem.State,
                    City = x.PersonalInfoItem.City,
                    Street = x.PersonalInfoItem.Street,
                    PostalCode = x.PersonalInfoItem.PostalCode,
                    PlaqueNo = x.PersonalInfoItem.PlaqueNo,
                    Mobile = x.PersonalInfoItem.Mobile,
                    Email = x.PersonalInfoItem.Email,
                    Description = x.PersonalInfoItem.Description

                }).Distinct().OrderByDescending(x=>x.OrderId).Take(3);


            return info.ToList();




        }

        public AccountViewModel GetAccountInformation(long accountId)
        {
            var account = _accountContext.Accounts
                .FirstOrDefault(x => x.Id == accountId);

            if (account==null)
            {
                return new AccountViewModel();
            }

            var accountInfo = new AccountViewModel
            {
                Id = account.Id,
                Mobile = account.Mobile,
                FullName = account.FullName,
                Username = account.Username,
                ProfilePhoto = account.ProfilePhoto,
                CreationDate = account.CreationDate.ToFarsi()
            };

            return accountInfo;
        }
    }
}
