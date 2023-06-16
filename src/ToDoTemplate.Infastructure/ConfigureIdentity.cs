using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Infastructure.Identity;
using ToDoTemplate.Infastructure.Identity.Services;

namespace ToDoTemplate.Infastructure
{
    public static class ConfigureIdentity
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {


            var usersdb = configuration.GetConnectionString("Identitydb");
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlite(usersdb));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;


            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders(); ;
            services.AddTransient<IAppUserService, AppUserService>();

            return services;
        }

    }
}
