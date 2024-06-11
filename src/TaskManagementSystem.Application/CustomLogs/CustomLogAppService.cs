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
using TaskManagementSystem.CustomLogs.Dto;
using Abp.Runtime.Session;

namespace TaskManagementSystem.CustomLogs
{
    public class CustomLogAppService : TaskManagementSystemAppServiceBase, ICustomLogAppService
    {
        private readonly IRepository<CustomLog, int> _customLogRepository;
        private readonly UserManager _userManager;
        public CustomLogAppService(IRepository<CustomLog, int> customLogRepository, UserManager userManager)
        {
            _customLogRepository = customLogRepository;
            _userManager = userManager;
        }

        public async Task<CustomLogDto> CreateAsync(CreateCustomLogDto input)
        {
            try
            {
                var log = ObjectMapper.Map<CustomLog>(input);

                await _customLogRepository.InsertAsync(log);

                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<CustomLogDto>(log);
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
        public async Task<PagedResultDto<CustomLogDto>> GetAllCustomLogs(PagedCustomLogResultRequestDto input)
        {
            var log = _customLogRepository.GetAll().OrderBy(c=>c.Id).PageBy(input);
            int count = await log.CountAsync();
            var list =await log.ToListAsync();
            var dto = list.Select(c=> new CustomLogDto
            {
               Description = c.Description,
               CreationTime = c.CreationTime.ToString("dd-MM-yyyy hh:mm tt"),
            }).ToList();

            return new PagedResultDto<CustomLogDto>(count, dto);
        }
        public async Task<User> GetCurrentUserName(long userId)
        {
            var user = await _userManager.GetUserByIdAsync(userId);
            return user;
        }

    }
}

