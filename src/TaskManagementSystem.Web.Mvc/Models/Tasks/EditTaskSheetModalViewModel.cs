using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.TaskSheets
{
    public class EditTaskSheetModalViewModel
    {
        public TaskSheetDto TaskSheet { get; set; }
        public IReadOnlyList<TeamDto> Teams { get; set; }
        public IReadOnlyList<UserDto> Users { get; set; }
    }
}
