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

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_TaskSheets)]
    public class TaskSheetsController : TaskManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ITaskSheetAppService _taskSheetAppService;

        public TaskSheetsController(IUserAppService userAppService, ITaskSheetAppService taskSheetAppService)
        {
            _userAppService = userAppService;
            _taskSheetAppService = taskSheetAppService;
        }

        public async Task<ActionResult> Index()
        {
            var tasks = (await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto()));
            var model = new TaskSheetListViewModel();
            return View(model);
        }

        public async Task<ActionResult> EditModal(int taskId)
        {
            var user = await _taskSheetAppService.GetAsync(new EntityDto<int>(taskId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel();
            return PartialView("_EditModal", model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
