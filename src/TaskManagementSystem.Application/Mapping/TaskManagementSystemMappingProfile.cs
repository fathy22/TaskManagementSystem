using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Tasks;

namespace TaskManagementSystem.Mapping
{
    public class TaskManagementSystemMappingProfile : Profile
    {
        public TaskManagementSystemMappingProfile()
        {
            //Team
            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
            CreateMap<TeamDto, Team>();

            //TeamMember
            CreateMap<CreateTeamMemberDto, TeamMember>();

            //Task
            CreateMap<CreateTaskSheetDto, TaskSheet>();
            CreateMap<TaskSheetDto, TaskSheet>();
        }
    }
}
