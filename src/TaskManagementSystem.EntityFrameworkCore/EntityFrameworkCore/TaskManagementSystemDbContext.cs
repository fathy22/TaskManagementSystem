using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using TaskManagementSystem.Authorization.Roles;
using TaskManagementSystem.Authorization.Users;
using TaskManagementSystem.MultiTenancy;
using TaskManagementSystem.Tasks;
using TaskManagementSystem.Teams;
using TaskManagementSystem.Attachments;

namespace TaskManagementSystem.EntityFrameworkCore
{
    public class TaskManagementSystemDbContext : AbpZeroDbContext<Tenant, Role, User, TaskManagementSystemDbContext>
    {
        public DbSet<TaskSheet> TaskSheets { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }


        public TaskManagementSystemDbContext(DbContextOptions<TaskManagementSystemDbContext> options)
            : base(options)
        {
        }
    }
}
