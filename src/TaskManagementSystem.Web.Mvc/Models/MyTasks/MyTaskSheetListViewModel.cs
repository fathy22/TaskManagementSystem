using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.MyTaskSheets
{
    public class MyTaskSheetListViewModel
    {
        public IReadOnlyList<TeamDto> Teams { get; set; }
        public IReadOnlyList<UserDto> Users { get; set; }
    }
}
