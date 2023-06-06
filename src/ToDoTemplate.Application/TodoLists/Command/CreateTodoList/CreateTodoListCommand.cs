using MediatR;

namespace ToDoTemplate.Application.TodoLists.Command.CreateTodoList
{
    public class CreateTodoListCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }

    }
}
