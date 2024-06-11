﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TaskManagementSystem.Authorization
{
    public class TaskManagementSystemAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_TaskSheets, L("Tasks"));
            context.CreatePermission(PermissionNames.Pages_MyTaskSheets, L("MyTasks"));
            context.CreatePermission(PermissionNames.Pages_TeamTaskSheets, L("TeamTasks"));
            context.CreatePermission(PermissionNames.Pages_Teams, L("Teams"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, TaskManagementSystemConsts.LocalizationSourceName);
        }
    }
}
