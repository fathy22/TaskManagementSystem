using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DashboardReports.Dto;
using TaskManagementSystem.TaskCommen;

namespace TaskManagementSystem.DashboardReports
{
    public interface IDashboardReportAppService 
    {
        Task<ReportDto> GetDashboardCards();
        Task<List<TopFiveUsersDto>> GetTopFiveUsersHaveTasks();
    }
}
