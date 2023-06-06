using MediatR;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetListTodoEntity
{
    public class GetListTodoEntityQuery : IRequest<GetListTodoEntityList>
    {
        public Guid UserId { get; set; }

    }
}
