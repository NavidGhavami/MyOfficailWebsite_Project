using _0_Framework.Infrastructure;
using Comment.Management.Domain.Comment;
using CommentManagement.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Configuration.Permissions;
using CommentManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Configuration
{
    public class CommentManagementBootstrapper 
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddTransient<IPermissionExposition, CommentPermissionExposition>();

            services.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
