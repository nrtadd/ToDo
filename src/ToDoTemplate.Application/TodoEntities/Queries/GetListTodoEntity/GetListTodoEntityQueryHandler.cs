using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.TodoEntities.Queries.Common;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetListTodoEntity
{
    public class GetListTodoEntityQueryHandler : IRequestHandler<GetListTodoEntityQuery, GetListTodoEntityList>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetListTodoEntityQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetListTodoEntityList> Handle(GetListTodoEntityQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.todoEntities.Where(todo => todo.UserId == request.UserId).AsNoTracking()
                .ProjectTo<GetTodoEntityVm>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (entities.Count == 0)
            {
                throw new NotFoundException(nameof(TodoList), request.UserId);
            }
            return new GetListTodoEntityList { list = entities };
        }
    }
}
