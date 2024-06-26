﻿using System.Threading.Tasks;
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
using Abp.Runtime.Session;
using TaskManagementSystem.Tasks.Dto;
using TaskManagementSystem.Teams.Dto;

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
                Users = users.Items,
                DependentTask = tasks.Items,
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(int taskId)
        {
            var task = await _taskSheetAppService.GetAsync(new EntityDto<int>(taskId));
            var users = await _userAppService.GetAllAsync(new Users.Dto.PagedUserResultRequestDto());
            var teams = await _teamAppService.GetAllAsync(new Teams.Dto.PagedTeamResultRequestDto());
            var tasks = await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto());
            var model = new EditTaskSheetModalViewModel
            {
                TaskSheet = task,
                Teams = teams.Items,
                Users = users.Items,
                DependentTask = tasks.Items.ToList()
            };
            return PartialView("_EditModal", model);
        }

        [HttpGet]
        public IActionResult GanttChart()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskSheetAppService.GetAllAsync(new Tasks.Dto.PagedTaskSheetResultRequestDto());
            var result = tasks.Items.Select(t => new TaskSheetDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                TaskStatus = t.TaskStatus,
                TaskPriority = t.TaskPriority,
                UserId = t.UserId,
                DependentTaskId = t.DependentTaskId,
                Team = new TeamDto
                {
                    Id = t.TeamId ?? 0,
                    Name = t.Team?.Name
                }
            }).ToList();

            return Json(new { result });
        }
    }
}
