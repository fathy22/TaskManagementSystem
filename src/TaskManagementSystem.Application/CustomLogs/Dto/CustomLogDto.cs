using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Attachments;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Helpers.Enums;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.CustomLogs.Dto
{
    [AutoMapFrom(typeof(CustomLog))]
    public class CustomLogDto : EntityDto<int>
    {
        public string Description { get; set; }
        public string CreationTime { get; set; }
    }
}
