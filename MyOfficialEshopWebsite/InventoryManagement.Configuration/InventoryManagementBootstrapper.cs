using InventoryManagement.Application;
using InventoryManagement.Application.Contract;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            //services.AddTransient<IPermissionExposition, InventoryPermissionExposition>();



            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
