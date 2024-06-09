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

namespace TaskManagementSystem.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Teams)]
    public class TeamsController : TaskManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ITeamAppService _TeamAppService;

        public TeamsController(IUserAppService userAppService, ITeamAppService TeamAppService)
        {
            _userAppService = userAppService;
            _TeamAppService = TeamAppService;
        }

        public async Task<ActionResult> Index()
        {
            var user = (await _userAppService.GetAllAsync(new Users.Dto.PagedUserResultRequestDto()));
            var teamLeaders = user.Items.Where(user => user.RoleNames.Any(role => role == StaticRoleNames.Host.TeamLeads)).ToList();
            var regularUsers = user.Items.Where(user => user.RoleNames.Any(role => role == StaticRoleNames.Host.RegularUsers)).ToList();
            var model = new TeamListViewModel
            {
                TeamLeaders = teamLeaders,
                RegularUsers  = regularUsers
            };
           
            return View(model);
        }

        public async Task<ActionResult> EditModal(int teamId)
        {
            try
            {
                var team = await _TeamAppService.GetAsync(new EntityDto<int>(teamId));
                var user = (await _userAppService.GetAllAsync(new Users.Dto.PagedUserResultRequestDto()));
                var teamLeaders = user.Items.Where(user => user.RoleNames.Any(role => role == StaticRoleNames.Host.TeamLeads)).ToList();
                var regularUsers = user.Items.Where(user => user.RoleNames.Any(role => role == StaticRoleNames.Host.RegularUsers)).ToList();
                var model = new EditTeamModalViewModel
                    {
                        Team = team,
                        TeamLeaders = teamLeaders,
                        RegularUsers = regularUsers
                };
                return PartialView("_EditModal", model);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}
