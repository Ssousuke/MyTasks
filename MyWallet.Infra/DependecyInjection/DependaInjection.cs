using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWallet.Dto.Dto;
using MyWallet.Dto.Mapping;
using MyWallet.Infra.AppDbContext;
using MyWallet.Infra.Interface;
using MyWallet.Infra.Repository;

namespace MyWallet.Infra.DependecyInjection
{
    public static class DependaInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(config.GetConnectionString("Dev"),
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ILogError, LogErrorRepository>();
            services.AddScoped<IBaseCrudRepository<ClientDto>, ClientRepository>();
            services.AddScoped<IBaseCrudRepository<ProjectDto>, ProjectRepository>();

            services.AddAutoMapper(typeof(MappingDomainToDto));

            return services;
        }
    }
}
