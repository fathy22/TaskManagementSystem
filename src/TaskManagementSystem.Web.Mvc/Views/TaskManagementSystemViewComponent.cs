using Abp.AspNetCore.Mvc.ViewComponents;

namespace TaskManagementSystem.Web.Views
{
    public abstract class TaskManagementSystemViewComponent : AbpViewComponent
    {
        protected TaskManagementSystemViewComponent()
        {
            LocalizationSourceName = TaskManagementSystemConsts.LocalizationSourceName;
        }
    }
}
