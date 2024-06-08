using Abp.Authorization;
using TaskManagementSystem.Authorization.Roles;
using TaskManagementSystem.Authorization.Users;

namespace TaskManagementSystem.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
