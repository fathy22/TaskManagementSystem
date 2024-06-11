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
using Abp.Runtime.Session;
using TaskManagementSystem.CustomLogs;
using TaskManagementSystem.Teams;

namespace TaskManagementSystem.Tasks
{
    public class TaskSheetsAppService : AsyncCrudAppService<TaskSheet, TaskSheetDto, int, PagedTaskSheetResultRequestDto, CreateTaskSheetDto, TaskSheetDto>, ITaskSheetAppService
    {
        private readonly ICustomLogAppService _customLogAppService;
        private readonly IAbpSession _abpSession;

        public TaskSheetsAppService(
            IRepository<TaskSheet, int> repository
       , ICustomLogAppService customLogAppService,
              IAbpSession abpSession) : base(repository)
        {
            _customLogAppService = customLogAppService;
            _abpSession = abpSession;
        }

        public async override Task<TaskSheetDto> CreateAsync(CreateTaskSheetDto input)
        {
            try
            {
                var TaskSheet = ObjectMapper.Map<TaskSheet>(input);

                await Repository.InsertAsync(TaskSheet);

                CurrentUnitOfWork.SaveChanges();
                var user = await _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value);
                await _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
                {
                    Description = $"{user.FullName} Created New Task : {input.Title}"
                });

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
                    var oldName = TaskSheet.Title;
                    ObjectMapper.Map(input, TaskSheet);
                    await Repository.UpdateAsync(TaskSheet);
                    var user = await _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value);
                    await _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
                    {
                        Description = $"{user.FullName} Updated Task from {oldName} to {TaskSheet.Title}"
                    });
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
            var item = Repository.GetAsync(input.Id).Result;
            var user = _customLogAppService.GetCurrentUserName(_abpSession.UserId.Value).Result;
            _customLogAppService.CreateAsync(new CustomLogs.Dto.CreateCustomLogDto
            {
                Description = $"{user.FullName} Deleted Task : {item.Title}"
            });
            return base.DeleteAsync(input);
        }

        protected override IQueryable<TaskSheet> CreateFilteredQuery(PagedTaskSheetResultRequestDto input)
        {
            return Repository
                .GetAll()
                .Include(c=>c.Team)
                .OrderByDescending(c => c.Id)
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

