using FluentValidation;

namespace ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity
{
    public class CreateTodoEntityValidator : AbstractValidator<CreateTodoEntityCommand>
    {
        public CreateTodoEntityValidator()
        {
            RuleFor(create => create.Title).NotEmpty().MaximumLength(100);         
            RuleFor(create => create.Description).NotEmpty().MaximumLength(100);
            RuleFor(create => create.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
