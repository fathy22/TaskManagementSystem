using System.Threading.Tasks;
using Abp.Application.Services;
using TaskManagementSystem.Authorization.Accounts.Dto;

namespace TaskManagementSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
