using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.TeamTaskSheets
{
    public class TeamTasksSheetListViewModel
    {
        public IReadOnlyList<UserDto> TeamMembers { get; set; }
        public IReadOnlyList<TaskSheetDto> DependentTask { get; set; }
        public int TeamId { get; set; }
    }
}
