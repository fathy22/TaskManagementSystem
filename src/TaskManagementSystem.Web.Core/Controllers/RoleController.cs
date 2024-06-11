using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using TaskManagementSystem.Authorization;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Users.Dto;
using TaskManagementSystem.CustomLogs;
using Microsoft.AspNetCore.Mvc;
using Abp.Runtime.Session;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Users;
using TaskManagementSystem.Controllers;
using TaskManagementSystem.Roles;

namespace TaskManagementSystem.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : TaskManagementSystemControllerBase
    {
        private readonly IRoleAppService _roleAppService;

        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto input)
        {
            var role = await _roleAppService.CreateAsync(input);
            return Ok(role);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto input)
        {
            var role = await _roleAppService.UpdateAsync(input);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleAppService.DeleteAsync(new EntityDto<int> { Id = id });
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _roleAppService.GetAsync(new EntityDto<int> { Id = id });
            return Ok(role);
        }
    }
}
