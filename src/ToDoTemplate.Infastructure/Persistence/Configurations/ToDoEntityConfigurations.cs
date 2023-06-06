using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Infastructure.Persistence.Configurations
{
    public class ToDoEntityConfigurations : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasIndex(entity => entity.Id).IsUnique();
            builder.Property(entity => entity.Title).HasMaxLength(100);
            builder.Property(entity => entity.Description).HasMaxLength(250);
        }
    }
}
