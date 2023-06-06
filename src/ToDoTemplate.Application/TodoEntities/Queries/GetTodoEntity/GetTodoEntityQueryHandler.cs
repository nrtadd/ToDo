using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.TodoEntities.Queries.Common;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetTodoEntity
{
    public class GetTodoEntityQueryHandler : IRequestHandler<GetTodoEntityQuery, GetTodoEntityVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoEntityQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetTodoEntityVm> Handle(GetTodoEntityQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.todoEntities.FirstOrDefaultAsync(todo => todo.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }
            return _mapper.Map<GetTodoEntityVm>(entity);
        }
    }
}
