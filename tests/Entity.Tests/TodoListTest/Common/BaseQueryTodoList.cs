using AutoMapper;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoListTest.Common
{
    public abstract class BaseQueryTodoList
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        protected BaseQueryTodoList()
        {
            _context = ContextTodoList.CreateDb();
            _mapper = (new MapperConfiguration(config => config.AddProfile(new AssemblyMap(typeof(IMap<>).Assembly)))).CreateMapper();
        }

        public void Dispose()
        {
            ContextTodoList.RemoveDateBase(_context);
        }
    }
}
