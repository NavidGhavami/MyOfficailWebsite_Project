using Microsoft.Extensions.DependencyInjection;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            

            



            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
