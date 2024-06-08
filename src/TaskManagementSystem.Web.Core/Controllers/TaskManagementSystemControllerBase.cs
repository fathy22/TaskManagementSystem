using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TaskManagementSystem.Controllers
{
    public abstract class TaskManagementSystemControllerBase: AbpController
    {
        protected TaskManagementSystemControllerBase()
        {
            LocalizationSourceName = TaskManagementSystemConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
