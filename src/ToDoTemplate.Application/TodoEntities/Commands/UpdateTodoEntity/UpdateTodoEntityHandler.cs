using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity
{
    public class UpdateTodoEntityHandler : IRequestHandler<UpdateTodoEntityCommand>
    {
        private readonly IAppDbContext _context;
        public UpdateTodoEntityHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateTodoEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.todoEntities.FirstOrDefaultAsync(todo => todo.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }
            entity.PriorityToDo = request.PriorityToDo;
            entity.EditDate = DateTime.Now;
            entity.Description = request.Description;
            entity.Title = request.Title;
            entity.IsDone = request.IsDone;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
