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
using TaskManagementSystem.Web.Models.TaskSheets;
using System.Linq;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Web.Models.Teams;
using TaskManagementSystem.Web.Models.TeamTaskSheets;
using Abp.Runtime.Session;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_TeamTaskSheets)]
    public class TeamTaskSheetsController : TaskManagementSystemControllerBase
    {
        private readonly IAbpSession _abpSession;
        private readonly ITaskSheetAppService _taskSheetAppService;
        private readonly IUserAppService _userAppService;
        private readonly ITeamAppService _teamAppService;

        public TeamTaskSheetsController(ITaskSheetAppService taskSheetAppService, IAbpSession abpSession, IUserAppService userAppService, ITeamAppService teamAppService)
        {
            _taskSheetAppService = taskSheetAppService;
            _abpSession = abpSession;
            _userAppService = userAppService;
            _teamAppService = teamAppService;
        }

        public async Task<ActionResult> Index()
        {
            var tasks = (await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto()));
            var team = await _teamAppService.GetTeamMembersByByTeamLeaderId(_abpSession.UserId.Value);
            var model = new TeamTasksSheetListViewModel()
            {
                TeamId = team.TeamId,
                TeamMembers = team.TeamMembers,
                DependentTask = tasks.Items,
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(int taskId)
        {
            var task = await _taskSheetAppService.GetAsync(new EntityDto<int>(taskId));
            var team = await _teamAppService.GetTeamMembersByByTeamLeaderId(_abpSession.UserId.Value);
            task.TeamId = team.TeamId;
            var tasks = await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto());
            var model = new EditTeamTaskSheetModalViewModel
            {
                TaskSheet = task,
                TeamMembers = team.TeamMembers,
                DependentTask = tasks.Items.ToList()
            };
            return PartialView("_EditModal", model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
