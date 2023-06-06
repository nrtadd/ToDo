using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Infastructure.Persistence;

namespace ToDoTemplate.Infastructure
{
    public static class ConfigureInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var entitydb = configuration.GetConnectionString("entitydb");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(entitydb));
            services.AddScoped<IAppDbContext>(config => config.GetRequiredService<AppDbContext>());
            return services;
        }
    }
}
