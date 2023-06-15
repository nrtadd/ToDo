using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoEntityTest.Common
{
    public abstract class BaseCommandTodoEntity : IDisposable
    {
        protected readonly AppDbContext _context;

        protected BaseCommandTodoEntity()
        {
            _context = ContextTodoEntity.CreateDb();
        }
        public void Dispose()
        {
            ContextTodoEntity.RemoveDateBase(_context);
        }
    }
}
