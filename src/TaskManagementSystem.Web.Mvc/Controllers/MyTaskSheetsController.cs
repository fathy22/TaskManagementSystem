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
using TaskManagementSystem.Web.Models.MyTaskSheets;
using Abp.Runtime.Session;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_MyTaskSheets)]
    public class MyTaskSheetsController : TaskManagementSystemControllerBase
    {
        private readonly IAbpSession _abpSession;
        private readonly ITaskSheetAppService _taskSheetAppService;

        public MyTaskSheetsController(ITaskSheetAppService taskSheetAppService, IAbpSession abpSession)
        {
            _taskSheetAppService = taskSheetAppService;
            _abpSession = abpSession;
        }

        public async Task<ActionResult> Index()
        {
            var tasks = (await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto()));
            var list = tasks.Items.Where(c => c.UserId == _abpSession.UserId.Value).ToList();
            var model = new MyTaskSheetListViewModel();
            return View(model);
        }

        public async Task<ActionResult> EditModal(int taskId)
        {
            var task = await _taskSheetAppService.GetAsync(new EntityDto<int>(taskId));
            var model = new EditTaskSheetModalViewModel
            {
                TaskSheet = task
            };
            return PartialView("_EditModal", model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
