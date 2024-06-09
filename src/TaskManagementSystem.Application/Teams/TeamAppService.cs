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

namespace TaskManagementSystem.Teams
{
    //[AbpAuthorize(PermissionNames.Pages_Teams)]
    public class TeamAppService : AsyncCrudAppService<Team, TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, UpdateTeamDto>, ITeamAppService
    {

        public TeamAppService(
            IRepository<Team, int> repository
        ) : base(repository)
        {
        }

        public async override Task<TeamDto> CreateAsync(CreateTeamDto input)
        {
            try
            {
                var Team = ObjectMapper.Map<Team>(input);

                await Repository.InsertAsync(Team);

                CurrentUnitOfWork.SaveChanges();

                return MapToEntityDto(Team);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async override Task<TeamDto> UpdateAsync(UpdateTeamDto input)
        {
            using (var unitOfWork = UnitOfWorkManager.Begin())
            {
                try
                {

                    var Team = await Repository.GetAsync(input.Id);

                    ObjectMapper.Map(input, Team);

                    await Repository.UpdateAsync(Team);

                    await unitOfWork.CompleteAsync();

                    return MapToEntityDto(Team);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public override Task DeleteAsync(EntityDto<int> input)
        {
            return base.DeleteAsync(input);
        }

        protected override IQueryable<Team> CreateFilteredQuery(PagedTeamResultRequestDto input)
        {
            return Repository
                .GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
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

