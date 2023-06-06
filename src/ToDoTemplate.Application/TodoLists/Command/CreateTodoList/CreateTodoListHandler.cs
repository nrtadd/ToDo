using MediatR;
using ToDoTemplate.Application.Common.Interfaces;
using ToDoTemplate.Domain.Entities;

namespace ToDoTemplate.Application.TodoLists.Command.CreateTodoList
{
    public class CreateTodoListHandler : IRequestHandler<CreateTodoListCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateTodoListHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var todolist = new TodoList
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CreationDate = DateTime.Now,
                EditDate = null,
                Title = request.Title,
                Todos = null
            };
            await _context.todoLists.AddAsync(todolist);
            await _context.SaveChangesAsync(cancellationToken);
            return todolist.Id;
        }
    }
}
