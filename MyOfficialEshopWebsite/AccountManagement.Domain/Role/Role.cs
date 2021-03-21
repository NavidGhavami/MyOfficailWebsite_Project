using System.Collections.Generic;
using _0_Framework;
using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AccountManagement.Domain.Role
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public Role()
        {
        }
        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Accounts = new List<Account>();
            Permissions = permissions;
        }

        public void Edit(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}
