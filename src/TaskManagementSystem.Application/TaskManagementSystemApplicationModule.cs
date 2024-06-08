using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementSystem.Authorization;

namespace TaskManagementSystem
{
    [DependsOn(
        typeof(TaskManagementSystemCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TaskManagementSystemApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TaskManagementSystemAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TaskManagementSystemApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
