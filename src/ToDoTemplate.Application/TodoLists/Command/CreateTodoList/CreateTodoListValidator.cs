using FluentValidation;

namespace ToDoTemplate.Application.TodoLists.Command.CreateTodoList
{
    public class CreateTodoListValidator : AbstractValidator<CreateTodoListCommand>
    {
        public CreateTodoListValidator()
        {
            RuleFor(create => create.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(create => create.Title).NotEmpty().MaximumLength(100);
        }
    }
}
