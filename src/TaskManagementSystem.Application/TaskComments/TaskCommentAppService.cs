using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.CustomLogs;
using TaskManagementSystem.CustomLogs.Dto;
using TaskManagementSystem.TaskCommen;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.TasksComment.Dto;

namespace TaskManagementSystem.TaskComments
{
    public class TaskCommentAppService : ApplicationService, ITaskCommentAppService
    {
        private readonly IRepository<TaskComment, int> _taskCommentRepository;
        private readonly ICustomLogAppService _customLogAppService;
        private readonly IAbpSession _abpSession;
        public TaskCommentAppService(ICustomLogAppService customLogAppService,IRepository<TaskComment, int> taskCommentRepository, IAbpSession abpSession)
        {
            _taskCommentRepository = taskCommentRepository;
            _customLogAppService = customLogAppService;
            _abpSession = abpSession;
        }

        public async Task<TaskCommentDto> CreateAsync(CreateTaskCommentDto input)
        {
            try
            {
                var comment = ObjectMapper.Map<TaskComment>(input);

                await _taskCommentRepository.InsertAsync(comment);

                CurrentUnitOfWork.SaveChanges();

                return ObjectMapper.Map<TaskCommentDto>(comment);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<PagedResultDto<TaskCommentDto>> GetAllCommentsByTaskId(int taskId)
        {
            var comments = _taskCommentRepository.GetAll()
                .Where(at => at.TaskSheetId == taskId);
            int count = await comments.CountAsync();
            var list = await comments.ToListAsync();

            var dto = ObjectMapper.Map<List<TaskCommentDto>>(comments);

            return new PagedResultDto<TaskCommentDto>(count, dto);
        }
    }
}
