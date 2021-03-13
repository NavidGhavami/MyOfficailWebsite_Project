using System.Collections.Generic;
using System.Reflection.Emit;
using _0_Framework.Application;
using _0_Framework.Domain;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        OperationResult CreateRole(CreateRole command);
        OperationResult EditRole(EditRole command);
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
