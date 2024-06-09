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
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Teams.Dto
{
    [AutoMapFrom(typeof(Team))]
    public class CreateTeamDto
    {
        public string Name { get; set; }
        public long TeamLeaderId { get; set; }
        public List<CreateTeamMemberDto> TeamMembers { get; set; }
    }
}
