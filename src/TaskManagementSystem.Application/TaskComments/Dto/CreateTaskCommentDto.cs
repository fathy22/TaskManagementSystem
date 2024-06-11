using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Tasks;

namespace TaskManagementSystem.TasksComment.Dto
{
    [AutoMapFrom(typeof(TaskComment))]
    public class CreateTaskCommentDto
    {
        public int TaskSheetId { get; set; }
        public string Comment { get; set; }

    }
}
