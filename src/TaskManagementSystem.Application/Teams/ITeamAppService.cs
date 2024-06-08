using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;

namespace TaskManagementSystem.Teams
{
    public interface ITeamAppService : IAsyncCrudAppService<TeamDto, int, PagedTeamResultRequestDto, CreateTeamDto, UpdateTeamDto>
    {
    }
}
