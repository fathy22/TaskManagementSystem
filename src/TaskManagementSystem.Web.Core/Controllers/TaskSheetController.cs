using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Controllers;
using Abp.Authorization;
using TaskManagementSystem.Authorization;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_TaskSheets)]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskSheetController : TaskManagementSystemControllerBase
    {
        private readonly ITaskSheetAppService _taskSheetAppService;

        public TaskSheetController(ITaskSheetAppService taskSheetAppService)
        {
            _taskSheetAppService = taskSheetAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<TaskSheetDto>> GetAll([FromQuery] PagedTaskSheetResultRequestDto input)
        {
            return await _taskSheetAppService.GetAllAsync(input);
        }

        [HttpGet("{id}")]
        public async Task<TaskSheetDto> Get(int id)
        {
            return await _taskSheetAppService.GetAsync(new EntityDto<int>(id));
        }

        [HttpPost]
        public async Task<TaskSheetDto> Create([FromBody] CreateTaskSheetDto input)
        {
            return await _taskSheetAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        public async Task<TaskSheetDto> Update(int id, [FromBody] TaskSheetDto input)
        {
            input.Id = id;
            return await _taskSheetAppService.UpdateAsync(input);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _taskSheetAppService.DeleteAsync(new EntityDto<int>(id));
        }
    }
}
