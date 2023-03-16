using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTasks.Dto.Dto;
using MyTasks.Dto.Mapping;
using MyTasks.Infra.AppDbContext;
using MyTasks.Infra.Interface;
using MyTasks.Infra.Repository;

namespace MyTasks.Infra.DependecyInjection
{
    public static class DependaInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(config.GetConnectionString("Dev"),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ILogError, LogErrorRepository>();
            services.AddScoped<IBaseCrudRepository<MyTasksDto>, MyTasksRepository>();
            services.AddScoped<IBaseCrudRepository<ProjectDto>, ProjectRepository>();

            services.AddAutoMapper(typeof(MappingDomainToDto));

            return services;
        }
    }
}
