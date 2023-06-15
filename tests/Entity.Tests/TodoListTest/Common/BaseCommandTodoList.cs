using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoListTest.Common
{
    public abstract class BaseCommandTodoList : IDisposable
    {
        protected readonly AppDbContext _context;

        protected BaseCommandTodoList()
        {
            _context = ContextTodoList.CreateDb();
        }
        public void Dispose()
        {
            ContextTodoList.RemoveDateBase(_context);
        }
    }
}
