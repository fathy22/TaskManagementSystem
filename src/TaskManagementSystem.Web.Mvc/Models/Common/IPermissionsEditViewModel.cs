using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;

namespace TaskManagementSystem.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}