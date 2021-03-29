using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace _0_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SignIn(AuthViewModel account)
        {
            var permission = JsonConvert.SerializeObject(account.Permissions);

            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.Username), // Or Use ClaimTypes.NameIdentifier
                new Claim("Fullname", account.FullName),
                new Claim("Picture", account.Picture),
                new Claim("permissions", permission),
                new Claim("Mobile",account.Mobile),

            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(3)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsAuthenticated()
        {

            return _contextAccessor.HttpContext.User.Identity != null && _contextAccessor.HttpContext.User.Identity.IsAuthenticated;

        }

        public string CurrentAccountRole()
        {
            return IsAuthenticated() ? _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value : null;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();

            if (!IsAuthenticated())
            {
                return new AuthViewModel();
            }

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();

            result.Id = long.Parse(claims.FirstOrDefault(x => x.Type == "AccountId").Value);
            result.FullName = claims.FirstOrDefault(x => x.Type == "Fullname")?.Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Username = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            result.Role = Roles.GetRoleBy(result.RoleId);
            result.Picture = claims.FirstOrDefault(x => x.Type == "Picture")?.Value;
            result.Mobile = claims.FirstOrDefault(x => x.Type == "Mobile")?.Value;
            


            return result;

        }

        public List<int> GetPermission()
        {
            if (!IsAuthenticated())
            {
                return new List<int>();
            }

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }

        public long CurrentAccountId()
        {
            return IsAuthenticated() ? long.Parse(_contextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "AccountId").Value) : 0;

        }
    }
}