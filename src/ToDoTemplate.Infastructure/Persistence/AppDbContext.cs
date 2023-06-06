using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;
using ToDoTemplate.Infastructure.Persistence.Configurations;

namespace ToDoTemplate.Infastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<TodoEntity> todoEntities { get; set; } = null!;
        public DbSet<TodoList> todoLists { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ToDoEntityConfigurations());
            builder.ApplyConfiguration(new ToDoListConfigurations());
            base.OnModelCreating(builder);
        }


    }
}
