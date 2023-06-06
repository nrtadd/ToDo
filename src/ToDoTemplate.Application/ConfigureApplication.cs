using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoTemplate.Application.Common.Behaviors;

namespace ToDoTemplate.Application
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Validator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(Logging<,>));
            return services;
        }
    }
}
