using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Application.TodoLists.Queries.Common;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoCatalog
{
    public class GetTodoCatalogQueryHandler : IRequestHandler<GetTodoCatalogQuery, GetTodoCatalog>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoCatalogQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetTodoCatalog> Handle(GetTodoCatalogQuery request, CancellationToken cancellationToken)
        {
            var lists = await _context.todoLists.Where(x => x.UserId == request.UserId).ProjectTo<GetTodoListVm>(_mapper.ConfigurationProvider).ToListAsync();
            if (lists.Count == 0)
            {
                throw new NotFoundException(nameof(TodoList), request.UserId);
            }
            return new GetTodoCatalog
            {
                catalog = lists
            };
        }
    }
}

