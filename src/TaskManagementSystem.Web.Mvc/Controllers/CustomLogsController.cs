using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using TaskManagementSystem.Authorization;
using TaskManagementSystem.Controllers;
using TaskManagementSystem.Users;
using TaskManagementSystem.Web.Models.Users;
using System.Threading.Tasks.Sources;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Web.Models.Teams;
using TaskManagementSystem.Web.Models.Roles;
using System.Linq;
using TaskManagementSystem.Authorization.Roles;
using StackExchange.Redis;
using TaskManagementSystem.CustomLogs;
using TaskManagementSystem.Web.Models.CustomLogs;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Logs)]
    public class CustomLogsController : TaskManagementSystemControllerBase
    {
        private readonly ICustomLogAppService _customLogAppService;

        public CustomLogsController(ICustomLogAppService customLogAppService)
        {
            _customLogAppService = customLogAppService;
        }

        public async Task<ActionResult> Index()
        {
            var logs = await _customLogAppService.GetAllCustomLogs(new CustomLogs.Dto.PagedCustomLogResultRequestDto());
            var model = new CustomLogListViewModel
            {
                Logs= logs.Items
            };
           
            return View(model);
        }
    }
}
