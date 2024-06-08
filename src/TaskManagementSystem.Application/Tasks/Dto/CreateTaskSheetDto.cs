using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Helpers.Enums;
using TaskManagementSystem.Teams;

namespace TaskManagementSystem.Tasks.Dto
{
    [AutoMapFrom(typeof(TaskSheet))]
    public class CreateTaskSheetDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskSheetStatus TaskStatus { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public long? UserId { get; set; }
        public int? AttachmentId { get; set; }
        public int? TeamId { get; set; }
    }
}
