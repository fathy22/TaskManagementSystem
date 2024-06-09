using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Helpers.Enums;
using TaskManagementSystem.Teams;

namespace TaskManagementSystem.Teams.Dto
{
    [AutoMapFrom(typeof(Team))]
    public class UpdateTeamDto : EntityDto<int>
    {
        public string Name { get; set; }
        public long TeamLeaderId { get; set; }
        public List<CreateTeamMemberDto> TeamMembers { get; set; }
    }
}
