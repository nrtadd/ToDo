using MediatR;
using ToDoTemplate.Domain.Enums;

namespace ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity
{
    public class CreateTodoEntityCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Priority PiorityToDo { get; set; }
    }
}
