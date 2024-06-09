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

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_TaskSheets)]
    public class TaskSheetsController : TaskManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ITeamAppService _teamAppService;
        private readonly ITaskSheetAppService _taskSheetAppService;

        public TaskSheetsController(ITeamAppService teamAppService,IUserAppService userAppService, ITaskSheetAppService taskSheetAppService)
        {
            _userAppService = userAppService;
            _taskSheetAppService = taskSheetAppService;
            _teamAppService = teamAppService;
        }

        public async Task<ActionResult> Index()
        {
            var tasks = (await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto()));
            var users = await _userAppService.GetAllAsync(new Users.Dto.PagedUserResultRequestDto());
            var teams = await _teamAppService.GetAllAsync(new Teams.Dto.PagedTeamResultRequestDto());
            var model = new TaskSheetListViewModel
            {
                Teams = teams.Items,
                Users = users.Items
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(int taskId)
        {
            var task = await _taskSheetAppService.GetAsync(new EntityDto<int>(taskId));
            var users = await _userAppService.GetAllAsync(new Users.Dto.PagedUserResultRequestDto());
            var teams = await _teamAppService.GetAllAsync(new Teams.Dto.PagedTeamResultRequestDto());
            var model = new EditTaskSheetModalViewModel
            {
                TaskSheet = task,
                Teams = teams.Items,
                Users = users.Items
            };
            return PartialView("_EditModal", model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
