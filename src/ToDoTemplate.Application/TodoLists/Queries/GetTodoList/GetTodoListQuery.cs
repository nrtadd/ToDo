using MediatR;
using ToDoTemplate.Application.TodoLists.Queries.Common;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoList
{
    public class GetTodoListQuery : IRequest<GetTodoListVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
