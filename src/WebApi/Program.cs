using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using ToDoTemplate.Application;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Infastructure;
using WebApi.Middleware.Exceptions;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, conf) => conf.ReadFrom.Configuration(builder.Configuration));
builder.Services.AddHealthChecks();
builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
builder.Services.AddApplication();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMap(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMap(typeof(AssemblyMap).Assembly));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "Jwt",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference =  new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }

    });
});
var app = builder.Build();
app.UseHealthChecks("/health");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI().UseDeveloperExceptionPage();
}
app.UseExceptionHandlerMiddlerware();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("CorsAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
