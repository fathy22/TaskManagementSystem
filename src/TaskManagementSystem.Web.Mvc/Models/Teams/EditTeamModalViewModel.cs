using Abp.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.Teams
{
    [AutoMapFrom(typeof(TeamDto))]
    public class EditTeamModalViewModel
    {
        public TeamDto Team { get; set; }

        public IReadOnlyList<UserDto> TeamLeaders { get; set; }
        public IReadOnlyList<UserDto> RegularUsers { get; set; }

    }
}
