using System.Threading.Tasks;
using Abp.Application.Services;
using TaskManagementSystem.Sessions.Dto;

namespace TaskManagementSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
