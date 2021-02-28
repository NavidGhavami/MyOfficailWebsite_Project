using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Product;
using ShopManagement.Infrastructure.EFCore;

namespace _01_Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories
                .Where(x => x.IsShow)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PrimaryPicture = x.PrimaryPicture,
                    SecondaryPicture = x.SecondaryPicture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug

                }).OrderByDescending(x => x.Id).Take(6).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesMiddleBanner()
        {
            return _shopContext.ProductCategories
                .Where(x => !x.IsShow)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    PrimaryPicture = x.PrimaryPicture,
                    SecondaryPicture = x.SecondaryPicture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug

                }).OrderByDescending(x => x.Id).Take(4).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = _inventoryContext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice });

            var dateTime = DateTime.Now;
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < dateTime && dateTime < x.EndDate)
                .Select(x => new { x.ProductId, x.DiscountRate });

            var categories = _shopContext.ProductCategories
                .Where(x => x.IsShow)
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products)

                }).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var price = inventory.FirstOrDefault(x => x.ProductId == product.Id)
                        .UnitPrice;
                    product.Price = price.ToMoney();



                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;

                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }


                }
            }


            return categories;
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProductsCount()
        {
            var categories = _shopContext.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SecondaryPicture = x.SecondaryPicture,
                    Products = MapProducts(x.Products)

                }).OrderByDescending(x => x.Id).Take(10).ToList();

            return categories;
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInMostSellProduct()
        {
            var inventory = _inventoryContext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice });

            var dateTime = DateTime.Now;
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < dateTime && dateTime < x.EndDate)
                .Select(x => new { x.ProductId, x.DiscountRate });

            var categories = _shopContext.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProductsMostSell(x.Products)

                }).OrderByDescending(x=>x.Id).Take(5).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var price = inventory.FirstOrDefault(x => x.ProductId == product.Id)
                        .UnitPrice;
                    product.Price = price.ToMoney();



                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;

                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }


                }
            }


            return categories;
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProductsInBestChoice()
        {
            var inventory = _inventoryContext.Inventories
                .Select(x => new { x.ProductId, x.UnitPrice });

            var dateTime = DateTime.Now;
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < dateTime && dateTime < x.EndDate)
                .Select(x => new { x.ProductId, x.DiscountRate });

            var categories = _shopContext.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProductsBestChoice(x.Products)

                }).OrderByDescending(x => x.Id).Take(5).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var price = inventory.FirstOrDefault(x => x.ProductId == product.Id)
                        .UnitPrice;
                    product.Price = price.ToMoney();



                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;

                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }


                }
            }


            return categories;
        }


        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                PrimaryPicture = product.PrimaryPicture,
                SecondaryPicture = product.SecondaryPicture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                BestChoice = product.BestChoice
            }).OrderByDescending(x => x.Id).Take(30).ToList();


        }
        private static List<ProductQueryModel> MapProductsMostSell(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                PrimaryPicture = product.PrimaryPicture,
                SecondaryPicture = product.SecondaryPicture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                Name = product.Name,
                ShortDescription = product.ShortDescription
            }).OrderByDescending(x => x.Price)
                .Take(48)
                .ToList();


        }
        private static List<ProductQueryModel> MapProductsBestChoice(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    PrimaryPicture = product.PrimaryPicture,
                    SecondaryPicture = product.SecondaryPicture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,
                    Name = product.Name,
                    ShortDescription = product.ShortDescription,
                    BestChoice = product.BestChoice
                }).OrderByDescending(x => x.Id)
                .Where(x=>x.BestChoice)
                .Take(25)
                .ToList();


        }


    }
}
