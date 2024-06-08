﻿using Abp.Domain.Entities.Auditing;
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

namespace TaskManagementSystem.Tasks
{
    public class TaskSheet:FullAuditedEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskSheetStatus TaskStatus { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? AttachmentId { get; set; }
        [ForeignKey("AttachmentId")]
        public Attachment Attachment { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public  Team Team { get; set; }
    }
}
