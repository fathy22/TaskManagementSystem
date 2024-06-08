using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TaskManagementSystem.Authorization.Roles;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.MultiTenancy;

namespace TaskManagementSystem.EntityFrameworkCore
{
    public class TaskManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, TaskManagementSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}
