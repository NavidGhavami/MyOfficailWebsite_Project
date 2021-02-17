using System.Collections.Generic;

namespace _0_Framework.Infrastructure
{
   
    public interface IPermissionExposition
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
