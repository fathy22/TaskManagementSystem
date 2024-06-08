using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;

namespace TaskManagementSystem.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
