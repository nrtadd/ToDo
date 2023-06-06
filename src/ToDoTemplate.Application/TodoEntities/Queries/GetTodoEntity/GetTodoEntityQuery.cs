using MediatR;
using ToDoTemplate.Application.TodoEntities.Queries.Common;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetTodoEntity
{
    public class GetTodoEntityQuery : IRequest<GetTodoEntityVm>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
