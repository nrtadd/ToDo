using MediatR;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoEntities.Commands.DeleteTodoEntity
{
    public class DeleteTodoEntityHandler : IRequestHandler<DeleteTodoEntityCommand>
    {
        public DeleteTodoEntityHandler(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;
        public async Task<Unit> Handle(DeleteTodoEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoEntities.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }
            _context.TodoEntities.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
