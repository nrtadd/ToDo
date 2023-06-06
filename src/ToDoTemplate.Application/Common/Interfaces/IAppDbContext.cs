using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<TodoEntity> todoEntities { get; set; }
        DbSet<TodoList> todoLists { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
