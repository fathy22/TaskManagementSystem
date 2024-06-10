using System.Collections.Generic;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.TaskSheets
{
    public class TaskSheetListViewModel
    {
        public IReadOnlyList<TeamDto> Teams { get; set; }
        public IReadOnlyList<UserDto> Users { get; set; }
        public IReadOnlyList<TaskSheetDto> DependentTask { get; set; }
    }
}
