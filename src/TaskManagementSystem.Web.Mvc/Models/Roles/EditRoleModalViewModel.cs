using Abp.AutoMapper;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Web.Models.Common;

namespace TaskManagementSystem.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
