using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskManagementSystem.CustomLogs.Dto;
using TaskManagementSystem.Authorization.Users;

namespace TaskManagementSystem.CustomLogs
{
    public interface ICustomLogAppService : IApplicationService
    {
        Task<CustomLogDto> CreateAsync(CreateCustomLogDto input);
        Task<PagedResultDto<CustomLogDto>> GetAllCustomLogs(PagedCustomLogResultRequestDto input);
        Task<User> GetCurrentUserName(long userId);
    }
}
