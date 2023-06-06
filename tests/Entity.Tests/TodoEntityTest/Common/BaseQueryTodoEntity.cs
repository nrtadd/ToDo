using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTemplate.Application.Common.Mapping;
using ToDoTemplate.Infastructure.Persistence;

namespace Entity.Tests.TodoEntityTest.Common
{
    public abstract class BaseQueryTodoEntity : IDisposable
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public BaseQueryTodoEntity()
        {
            _context = ContextTodoEntity.CreateDb();
            _mapper = (new MapperConfiguration(config => config.AddProfile(new AssemblyMap(typeof(IMap<>).Assembly)))).CreateMapper();
        }

        public void Dispose()
        {
           ContextTodoEntity.RemoveDateBase(_context);
        }
    }
}
