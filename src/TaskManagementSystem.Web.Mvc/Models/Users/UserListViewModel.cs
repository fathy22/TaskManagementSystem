using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;

namespace TaskManagementSystem.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
