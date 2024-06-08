using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementSystem.Configuration;

namespace TaskManagementSystem.Web.Host.Startup
{
    [DependsOn(
       typeof(TaskManagementSystemWebCoreModule))]
    public class TaskManagementSystemWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TaskManagementSystemWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagementSystemWebHostModule).GetAssembly());
        }
    }
}
