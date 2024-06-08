using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TaskManagementSystem.Tasks.Dto;

namespace TaskManagementSystem.Tasks
{
    public interface ITaskSheetAppService : IAsyncCrudAppService<TaskSheetDto, int, PagedTaskSheetResultRequestDto, CreateTaskSheetDto, UpdateTaskSheetDto>
    {
    }
}
