using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.DashboardReports.Dto;
using TaskManagementSystem.TaskCommen;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Teams;

namespace TaskManagementSystem.DashboardReports
{
    public class DashboardReportAppService : ApplicationService, IDashboardReportAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Team, int> _teamRepository;
        private readonly IRepository<TaskSheet, int> _taskRepository;
        public DashboardReportAppService(IRepository<TaskSheet, int> taskRepository, IRepository<User, long> userRepository, IRepository<Team, int> teamRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }
        public async Task<ReportDto> GetDashboardCards()
        {
            var data = new ReportDto();

            data.UsersCount = await _userRepository.GetAll().Where(c=>!c.IsDeleted).CountAsync();
            data.TeamsCount = await _teamRepository.GetAll().Where(c => !c.IsDeleted).CountAsync();
            data.AllTasksCount = await _taskRepository.GetAll().Where(c => !c.IsDeleted).CountAsync();
            data.CompletedTasksCount = await _taskRepository.GetAll().Where(c => !c.IsDeleted && c.TaskStatus == Helpers.Enums.TaskSheetStatus.Completed).CountAsync();
            data.ToDoTasksCount = await _taskRepository.GetAll().Where(c => !c.IsDeleted && c.TaskStatus == Helpers.Enums.TaskSheetStatus.ToDo).CountAsync();
            data.InProgressTasksCount = await _taskRepository.GetAll().Where(c => !c.IsDeleted && c.TaskStatus == Helpers.Enums.TaskSheetStatus.InProgress).CountAsync();
            return data;
        }

        public async Task<List<TopFiveUsersDto>> GetTopFiveUsersHaveTasks()
        {
            var data = new List<TopFiveUsersDto>();

            var tasks = _taskRepository.GetAll().Where(c => !c.IsDeleted);

            var count =await tasks.GroupBy(t => t.UserId).Select(v => new TopFiveUsersDto
            {
                UserName=v.FirstOrDefault().User.FullName,
                HisTasksCount =v.Count(),
            }).ToListAsync();
            var list = count.OrderByDescending(v => v.HisTasksCount).Take(5).ToList();
            return list;
        }
    }
}
