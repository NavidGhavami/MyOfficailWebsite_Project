using System.Linq;
using System.Reflection;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiceHost.Services
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission = (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute
                (typeof(NeedPermissionAttribute));

            if (handlerPermission == null)
            {
                return;
            }
            var accountPermissions = _authHelper.GetPermission();

            if (accountPermissions.All(x => x != handlerPermission.Permission))
            {
                context.HttpContext.Response.Redirect("/AccessDenied");
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }
    }
}
