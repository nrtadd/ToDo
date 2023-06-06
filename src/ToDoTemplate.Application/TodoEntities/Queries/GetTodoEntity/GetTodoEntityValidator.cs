using FluentValidation;

namespace ToDoTemplate.Application.TodoEntities.Queries.GetTodoEntity
{
    public class GetTodoEntityValidator : AbstractValidator<GetTodoEntityQuery>
    {
        public GetTodoEntityValidator()
        {
            RuleFor(getentity => getentity.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(getentity => getentity.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
