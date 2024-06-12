using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using TaskManagementSystem.Authorization;

namespace TaskManagementSystem.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class TaskManagementSystemNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                  .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    ))
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                    )
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.Tasks,
                        L("Tasks"),
                        url: "TaskSheets",
                        icon: "fas fa-tasks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_TaskSheets)
                    ))
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.Teams,
                        L("Teams"),
                        url: "Teams",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Teams)
                    )).AddItem(
                    new MenuItemDefinition(
                        PageNames.MyTasks,
                        L("MyTasks"),
                        url: "MyTaskSheets",
                        icon: "fas fa-tasks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_MyTaskSheets)
                    ))
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.TeamTasks,
                        L("TeamTasks"),
                        url: "TeamTaskSheets",
                        icon: "fas fa-tasks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_TeamTaskSheets)
                    ))
                    .AddItem(
                    new MenuItemDefinition(
                        PageNames.Logs,
                        L("Logs"),
                        url: "CustomLogs",
                        icon: "fas fa-file-alt",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Logs)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaskManagementSystemConsts.LocalizationSourceName);
        }
    }
}