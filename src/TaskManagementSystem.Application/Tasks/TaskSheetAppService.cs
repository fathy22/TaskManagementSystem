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
namespace TaskManagementSystem.Tasks
{
    public class TaskSheetsAppService : AsyncCrudAppService<TaskSheet, TaskSheetDto, int, PagedTaskSheetResultRequestDto, CreateTaskSheetDto, TaskSheetDto>, ITaskSheetAppService
    {

        public TaskSheetsAppService(
            IRepository<TaskSheet, int> repository
        ) : base(repository)
        {
        }

        public async override Task<TaskSheetDto> CreateAsync(CreateTaskSheetDto input)
        {
            try
            {
                var TaskSheet = ObjectMapper.Map<TaskSheet>(input);

                await Repository.InsertAsync(TaskSheet);

                CurrentUnitOfWork.SaveChanges();

                return MapToEntityDto(TaskSheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public async override Task<TaskSheetDto> UpdateAsync(TaskSheetDto input)
        {
            using (var unitOfWork = UnitOfWorkManager.Begin())
            {
                try
                {

                    var TaskSheet = await Repository.GetAsync(input.Id);

                    ObjectMapper.Map(input, TaskSheet);

                    await Repository.UpdateAsync(TaskSheet);

                    await unitOfWork.CompleteAsync();

                    return MapToEntityDto(TaskSheet);
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

        protected override IQueryable<TaskSheet> CreateFilteredQuery(PagedTaskSheetResultRequestDto input)
        {
            return Repository
                .GetAll()
                .Include(c=>c.Team)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Title.Contains(input.Keyword))
                .WhereIf(input.UserId.HasValue, x => x.UserId == input.UserId)
                .WhereIf(input.TeamId.HasValue, x => x.TeamId == input.TeamId);
        }
        protected override async Task<TaskSheet> GetEntityByIdAsync(int id)
        {
            return await Repository
                   .GetAll().Include(t => t.Attachment).Include(b=>b.Team)
                   .FirstOrDefaultAsync(t => t.Id == id);
        }

    }
}

