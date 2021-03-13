using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public List<int> Permissions { get; set; }
        public string Picture { get; set; }


        public AuthViewModel()
        {
        }

        public AuthViewModel(long id, long roleId, string fullName, string username, string picture/*, List<int> permissions*/)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            Username = username;
            Picture = picture;
            //Permissions = permissions;
        }
    }
}