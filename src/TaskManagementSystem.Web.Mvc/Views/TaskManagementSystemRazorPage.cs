using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace TaskManagementSystem.Web.Views
{
    public abstract class TaskManagementSystemRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TaskManagementSystemRazorPage()
        {
            LocalizationSourceName = TaskManagementSystemConsts.LocalizationSourceName;
        }
    }
}
