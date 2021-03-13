using System.Collections.Generic;
using _0_Framework.Domain;
using AccountManagement.Application.Contract.Role;

namespace AccountManagement.Domain.Role
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
