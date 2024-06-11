using System.Collections.Generic;
using TaskManagementSystem.CustomLogs.Dto;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.Roles.Dto;
using TaskManagementSystem.Users.Dto;

namespace TaskManagementSystem.Web.Models.CustomLogs
{
    public class CustomLogListViewModel
    {
        public IReadOnlyList<CustomLogDto> Logs { get; set; }
    }
}
