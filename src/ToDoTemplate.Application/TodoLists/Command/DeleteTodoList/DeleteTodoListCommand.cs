using MediatR;

namespace ToDoTemplate.Application.TodoLists.Command.DeleteTodoList
{
    public class DeleteTodoListCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
