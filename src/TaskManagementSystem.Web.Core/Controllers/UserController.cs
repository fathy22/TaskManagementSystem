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

namespace TaskManagementSystem.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : TaskManagementSystemControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(
            IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<PagedResultDto<UserDto>> GetAll([FromQuery] PagedUserResultRequestDto input)
        {
            return await _userAppService.GetAllAsync(input);
        }

        [HttpGet("{id}")]
        public async Task<UserDto> Get(long id)
        {
            return await _userAppService.GetAsync(new EntityDto<long>(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userAppService.CreateAsync(input);
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(long id, [FromBody] UserDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            input.Id = id;
            var result = await _userAppService.UpdateAsync(input);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _userAppService.DeleteAsync(new EntityDto<long>(id));
        }

        [HttpPost("{id}/activate")]
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task Activate(long id)
        {
            await _userAppService.Activate(new EntityDto<long>(id));
        }

        [HttpPost("{id}/deactivate")]
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task DeActivate(long id)
        {
            await _userAppService.DeActivate(new EntityDto<long>(id));
        }

        [HttpGet("roles")]
        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            return await _userAppService.GetRoles();
        }

        [HttpPost("change-language")]
        public async Task ChangeLanguage([FromBody] ChangeUserLanguageDto input)
        {
            await _userAppService.ChangeLanguage(input);
        }

        [HttpPost("change-password")]
        public async Task<ActionResult<bool>> ChangePassword([FromBody] ChangePasswordDto input)
        {
            var result = await _userAppService.ChangePassword(input);
            return Ok(result);
        }
    }
}
