using MediatR;
using ToDoTemplate.Domain.Enums;

namespace ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity
{
    public class UpdateTodoEntityCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Priority PriorityToDo { get; set; }
        public bool IsDone { get; set; }
    }
}
