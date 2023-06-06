using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Infastructure.Persistence.Configurations
{
    public class ToDoListConfigurations : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasIndex(entity => entity.Id).IsUnique();
            builder.Property(entity => entity.Title).HasMaxLength(100);

        }
    }
}
