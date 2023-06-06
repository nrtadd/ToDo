using MediatR;

namespace ToDoTemplate.Application.TodoEntities.Commands.DeleteTodoEntity
{
    public class DeleteTodoEntityCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

    }
}
