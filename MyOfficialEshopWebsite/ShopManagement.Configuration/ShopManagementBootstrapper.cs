using _0_Framework.Infrastructure;
using _01_LampshadeQuery.Query;
using _01_Query.Contract.Cart;
using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using _01_Query.Contract.Slider;
using _01_Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slider;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.Order;
using ShopManagement.Domain.Product;
using ShopManagement.Domain.ProductCategory;
using ShopManagement.Domain.ProductPicture;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.Slider;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;
using ShopManagement.Infrastructure.InventoryAcl;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISliderApplication, SliderApplication>();
            services.AddTransient<ISliderRepository, SliderRepository>();

            services.AddTransient<ISliderQuery, SliderQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddTransient<IPermissionExposition, ShopPermissionExposition>();

            services.AddTransient<ICartCalculatorService, CartCalculatorService>();

            services.AddSingleton<ICartService, CartService>();

            services.AddTransient<IOrderApplication, OrderApplication>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();





            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}