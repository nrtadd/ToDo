using FluentValidation;

namespace ToDoTemplate.Application.TodoLists.Command.UpdateTodoList
{
    public class UpdateTodoListValidator : AbstractValidator<UpdateTodoListCommand>
    {
        public UpdateTodoListValidator()
        {
            RuleFor(update => update.Title).NotEmpty().MaximumLength(100);
            RuleFor(update => update.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(update => update.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleForEach(update => update.Todos).NotEqual(Guid.Empty);
        }
    }
}
