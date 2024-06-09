using System.Collections.Generic;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.Teams
{
    public class TeamListViewModel
    {
        public IReadOnlyList<UserDto> TeamLeaders { get; set; }
        public IReadOnlyList<UserDto> RegularUsers { get; set; }
    }
}
