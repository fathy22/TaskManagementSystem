using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.TeamTaskSheets
{
    public class EditTeamTaskSheetModalViewModel
    {
        public TaskSheetDto TaskSheet { get; set; }
        public IReadOnlyList<UserDto> TeamMembers { get; set; }
        public List<TaskSheetDto> DependentTask { get; set; }
    }
}
