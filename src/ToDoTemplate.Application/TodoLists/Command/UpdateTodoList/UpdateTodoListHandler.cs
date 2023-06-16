using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Command.UpdateTodoList
{
    public class UpdateTodoListHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateTodoListHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var list = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (list == null || list.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }
            if (request.Todos != null)
            {
                var todoentity = await _context.TodoEntities.Where(x => request.Todos.Contains(x.Id)).ToListAsync(cancellationToken);
                if (todoentity == null || todoentity.Exists(x => x.UserId != request.UserId))
                {
                    throw new NotFoundException(nameof(TodoEntity), request.Todos);
                }
                list.Todos = new List<TodoEntity>(todoentity);

            }
            list.EditDate = DateTime.Now;
            list.Title = request.Title;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
