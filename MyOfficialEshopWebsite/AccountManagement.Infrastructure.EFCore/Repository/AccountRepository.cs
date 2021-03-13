using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _accountContext;

        public AccountRepository(AccountContext accountContext) : base(accountContext)
        {
            _accountContext = accountContext;
        }

        public Account GetBy(string username)
        {
            return _accountContext.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public EditAccount GetDetails(long id)
        {
            return _accountContext.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                RoleId = x.RoleId,
                FullName = x.FullName,
                Username = x.Username,
                Mobile = x.Mobile
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            var query = _accountContext.Accounts
                .Include(x=>x.Role)
                .Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Username = x.Username,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                Mobile = x.Mobile,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
            {
                query = query.Where(x => x.FullName.Contains(searchModel.FullName));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Username))
            {
                query = query.Where(x => x.Username.Contains(searchModel.Username));
            }
            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
            {
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));
            }
            if (searchModel.RoleId > 0)
            {
                query = query.Where(x => x.RoleId == searchModel.RoleId);
            }


            return query.OrderByDescending(x => x.Id).ToList();

        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountContext.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName

            }).ToList();
        }
    }
}
