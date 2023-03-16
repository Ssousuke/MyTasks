using Microsoft.EntityFrameworkCore;
using MyTasks.Domain.Entities;

namespace MyTasks.Infra.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LogError> LogErrors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
