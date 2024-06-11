using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using TaskManagementSystem.Authorization;
using TaskManagementSystem.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Roles.Dto;
using Abp.Domain.Uow;
using Abp.UI;
using System;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Users.Dto;
using TaskManagementSystem.CustomLogs;
using Abp.Runtime.Session;

namespace TaskManagementSystem.Teams
{
    public class TeamAppService : AsyncCrudAppService<Team, TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, TeamDto>, ITeamAppService
    {
        private readonly ICustomLogAppService _customLogAppService;
        private readonly IAbpSession _abpSession;   
        public TeamAppService(
            IRepository<Team, int> repository
          , ICustomLogAppService customLogAppService,
IAbpSession abpSession) : base(repository)
        {
            _customLogAppService = customLogAppService;
            _abpSession = abpSession;
        }

        public async override Task<TeamDto> CreateAsync(CreateTeamDto input)
        {
            try
            {
                var Team = ObjectMapper.Map<Team>(input);

                await Repository.InsertAsync(Team);

                CurrentUnitOfWork.SaveChanges();
                var user = await _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value);
                await _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
                {
                    Description= $"{user.FullName} Created New Team : {input.Name}"
                });

                return MapToEntityDto(Team);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async override Task<TeamDto> UpdateAsync(TeamDto input)
        {
            using (var unitOfWork = UnitOfWorkManager.Begin())
            {
                try
                {

                    var team = await Repository.GetAsync(input.Id);
                    var oldName = team.Name;
                    ObjectMapper.Map(input, team);

                    await Repository.UpdateAsync(team);
                    var user = await _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value);
                    await _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
                    {
                        Description = $"{user.FullName} Updated Team from {oldName} to {team.Name}"
                    });

                    await unitOfWork.CompleteAsync();

                    return MapToEntityDto(team);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public override Task DeleteAsync(EntityDto<int> input)
        {
            var item = Repository.GetAsync(input.Id).Result;
            var user = _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value).Result;
             _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
            {
                Description = $"{user.FullName} Deleted Team : {item.Name}"
            });
            return base.DeleteAsync(input);
        }

        protected override IQueryable<Team> CreateFilteredQuery(PagedTeamResultRequestDto input)
        {
            var teams =  Repository
                .GetAll()
                 .OrderByDescending(c => c.Id);
            return teams;
        }
        protected override async Task<Team> GetEntityByIdAsync(int id)
        {
            try
            {
                var team = await Repository.GetAll().Include(c=>c.TeamLeader).FirstOrDefaultAsync(t=>t.Id == id);
                return team;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }
        public async Task<TeamShowDto> GetTeamMembersByByTeamLeaderId(long teamLeaderId)
        {
            try
            {
                var data = new TeamShowDto();
                var team = await Repository.GetAll()
                    .Include(c => c.TeamMembers).ThenInclude(m=>m.Member)
                    .FirstOrDefaultAsync(t => t.TeamLeaderId == teamLeaderId);
                data.TeamMembers= team.TeamMembers.Select(u => new UserDto
                {
                    Id=u.MemberId,
                    FullName = u.Member.FullName
                }).ToList();
                data.TeamId = team.Id;
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}

