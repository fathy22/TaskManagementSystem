using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.TasksComment.Dto;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.TaskSheets
{
    public class AddCommentModalViewModel
    {
        public TaskCommentDto TaskComment { get; set; }
    }
}
