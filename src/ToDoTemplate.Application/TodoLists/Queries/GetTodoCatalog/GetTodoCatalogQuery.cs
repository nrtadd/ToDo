using MediatR;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoCatalog
{
    public class GetTodoCatalogQuery : IRequest<GetTodoCatalog>
    {
        public Guid UserId { get; set; }
    }
}
