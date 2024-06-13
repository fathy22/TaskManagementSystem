using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Attachments;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Helpers.Enums;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Tasks.Dto
{
    [AutoMapFrom(typeof(TaskSheet))]
    public class TaskSheetDto : EntityDto<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskSheetStatus TaskStatus { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public long? UserId { get; set; }
        public UserDto User { get; set; }
        public int? AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        public int? TeamId { get; set; }
        public TeamDto Team { get; set; }
        public int? DependentTaskId { get; set; }
    }
}
