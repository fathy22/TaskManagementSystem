using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Teams.Dto;
using TaskManagementSystem.Controllers;
using Abp.Authorization;
using TaskManagementSystem.Authorization;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_Teams)]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : TaskManagementSystemControllerBase
    {
        private readonly ITeamAppService _teamAppService;

        public TeamController(ITeamAppService teamAppService)
        {
            _teamAppService = teamAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<TeamDto>> GetAll([FromQuery] PagedTeamResultRequestDto input)
        {
            return await _teamAppService.GetAllAsync(input);
        }

        [HttpGet("{id}")]
        public async Task<TeamDto> Get(int id)
        {
            return await _teamAppService.GetAsync(new EntityDto<int>(id));
        }

        [HttpPost]
        public async Task<TeamDto> Create([FromBody] CreateTeamDto input)
        {
            return await _teamAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<TeamDto> Update(int id, [FromBody] TeamDto input)
        {
            input.Id = id;
            return await _teamAppService.UpdateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _teamAppService.DeleteAsync(new EntityDto<int>(id));
        }
    }
}
