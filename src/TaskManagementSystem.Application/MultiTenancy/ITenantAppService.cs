using Abp.Application.Services;
using TaskManagementSystem.MultiTenancy.Dto;

namespace TaskManagementSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

