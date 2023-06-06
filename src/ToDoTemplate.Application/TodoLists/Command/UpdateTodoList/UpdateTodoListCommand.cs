using MediatR;

namespace ToDoTemplate.Application.TodoLists.Command.UpdateTodoList
{
    public class UpdateTodoListCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public List<Guid>? Todos { get; set; }
    }
}
