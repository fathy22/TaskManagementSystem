using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TaskManagementSystem.Controllers;
using TaskManagementSystem.DashboardReports;
using TaskManagementSystem.Authorization;
using System.Threading.Tasks;
using TaskManagementSystem.Web.Models.Dashboards;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Admin_Dashboard)]
    public class HomeController : TaskManagementSystemControllerBase
    {
        private readonly IDashboardReportAppService _dashboardReportAppService;
        public HomeController(IDashboardReportAppService dashboardReportAppService)
        {
            _dashboardReportAppService = dashboardReportAppService;
        }

        public async Task<ActionResult> Index()
        {
            var counts = await _dashboardReportAppService.GetDashboardCards();
            var userTasks = await _dashboardReportAppService.GetTopFiveUsersHaveTasks();
            var model = new DashboardViewModel
            {
                Report = counts,
               TopFiveUsers = userTasks
            };
            return View(model);
        }
    }
}
