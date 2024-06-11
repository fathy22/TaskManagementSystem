using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams;

namespace TaskManagementSystem.TasksComment.Dto
{
    [AutoMapFrom(typeof(TaskComment))]
    public class TaskCommentDto
    {
        public int TaskSheetId { get; set; }
        public TaskSheetDto TaskSheet { get; set; }
        public string Comment { get; set; }
    }
}
