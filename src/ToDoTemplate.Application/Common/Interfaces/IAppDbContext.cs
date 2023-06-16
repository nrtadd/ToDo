using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<TodoEntity> TodoEntities { get; set; }
        DbSet<TodoList> TodoLists { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
