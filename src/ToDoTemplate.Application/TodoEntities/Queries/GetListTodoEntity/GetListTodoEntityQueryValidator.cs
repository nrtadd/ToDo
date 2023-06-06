using FluentValidation;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetListTodoEntity
{
    public class GetListTodoEntityQueryValidator : AbstractValidator<GetListTodoEntityQuery>
    {
        public GetListTodoEntityQueryValidator()
        {
            RuleFor(getlist => getlist.UserId).NotEmpty().NotEqual(Guid.Empty);
        }

    }
}
