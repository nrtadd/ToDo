using MediatR;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Command.DeleteTodoList
{
    public class DeleteTodoListHandler : IRequestHandler<DeleteTodoListCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteTodoListHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.todoLists.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoList), request.Id);
            }
            _context.todoLists.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
