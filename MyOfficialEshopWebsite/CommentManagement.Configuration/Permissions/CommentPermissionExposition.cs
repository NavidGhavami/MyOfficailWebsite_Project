using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace CommentManagement.Configuration.Permissions
{
    public class CommentPermissionExposition : IPermissionExposition
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {"Comment", new List<PermissionDto>
                {
                    new PermissionDto(CommentPermission.ConfirmComment,"تایید کردن کامنت"),
                    new PermissionDto(CommentPermission.CancelComment,"کنسل کردن کامنت"),
                }},
               
            };
        }
    }
}
