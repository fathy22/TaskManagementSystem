using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Tasks.Dto;

namespace TaskManagementSystem.Web.Models.TaskSheets
{
    public class EditTaskSheetModalViewModel
    {
        public TaskSheetDto TaskSheet { get; set; }

        //public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
