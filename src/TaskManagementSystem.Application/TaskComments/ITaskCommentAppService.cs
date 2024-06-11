using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.TasksComment.Dto;

namespace TaskManagementSystem.TaskCommen
{
    public interface ITaskCommentAppService
    {
        Task<PagedResultDto<TaskCommentDto>> GetAllCommentsByTaskId(int taskId);
        Task<TaskCommentDto> CreateAsync(CreateTaskCommentDto input);
    }
}
