using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Domain.CustomerDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using ShopManagement.Infrastructure.EFCore;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        { 
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate = x.EndDate.ToString(),
                DiscountReason = x.DiscountReason
                

            }).FirstOrDefault(x => x.Id == id);

        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name });

            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                DiscountReason = x.DiscountReason,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                CreationDate = x.CreationDate.ToFarsi()

            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateGr <= searchModel.StartDate.ToGeorgianDateTime());
            }
            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                
                query = query.Where(x => x.EndDateGr >= searchModel.EndDate.ToGeorgianDateTime());
            }

            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(d => d.Product = product.FirstOrDefault(x => x.Id == d.ProductId)?.Name);


            return discount;
        }


    }
}
