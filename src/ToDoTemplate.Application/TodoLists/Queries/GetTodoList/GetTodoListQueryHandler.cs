using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.TodoLists.Queries.Common;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, GetTodoListVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetTodoListVm> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.TodoLists.Include(x => x.Todos).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (list == null || list.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }
            return _mapper.Map<GetTodoListVm>(list);
        }
    }
}
