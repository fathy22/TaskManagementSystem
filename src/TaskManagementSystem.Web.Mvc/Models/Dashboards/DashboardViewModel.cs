using System.Collections.Generic;
using TaskManagementSystem.DashboardReports.Dto;

namespace TaskManagementSystem.Web.Models.Dashboards
{
    public class DashboardViewModel
    {
        public ReportDto Report { get; set; }
        public List<TopFiveUsersDto> TopFiveUsers { get; set; }
    }
}
