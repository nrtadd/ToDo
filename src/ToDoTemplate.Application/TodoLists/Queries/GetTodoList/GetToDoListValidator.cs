using FluentValidation;

namespace ToDoTemplate.Application.TodoLists.Queries.GetTodoList
{
    public class GetToDoListValidator : AbstractValidator<GetTodoListQuery>
    {
        public GetToDoListValidator()
        {
            RuleFor(getlist => getlist.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(getlist => getlist.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
