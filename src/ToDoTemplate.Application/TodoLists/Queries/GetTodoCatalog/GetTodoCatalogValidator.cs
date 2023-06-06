using FluentValidation;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoCatalog
{
    public class GetTodoCatalogValidator : AbstractValidator<GetTodoCatalogQuery>
    {
        public GetTodoCatalogValidator()
        {
            RuleFor(getcatalog => getcatalog.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
