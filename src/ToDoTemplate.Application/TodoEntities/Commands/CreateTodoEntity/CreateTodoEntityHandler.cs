using MediatR;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity
{
    public class CreateTodoEntityHandler : IRequestHandler<CreateTodoEntityCommand, Guid>
    {
        public CreateTodoEntityHandler(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;


        public async Task<Guid> Handle(CreateTodoEntityCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoEntity
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                PriorityToDo = request.PiorityToDo,
                IsDone = false,
                CreationDate = DateTime.Now,
                EditDate = null,
                todoList = null,
            };
            await _context.todoEntities.AddAsync(todo);
            await _context.SaveChangesAsync(cancellationToken);
            return todo.Id;

        }
    }
}
