using FluentValidation;

namespace ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity
{
    public class UpdateTodoEntityValidator : AbstractValidator<UpdateTodoEntityCommand>
    {
        public UpdateTodoEntityValidator()
        {
            RuleFor(update => update.Title).NotEmpty().MaximumLength(100);
            RuleFor(update => update.Description).NotEmpty().MaximumLength(100);
            RuleFor(update => update.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(update => update.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(update => update.PriorityToDo).NotEmpty();
            RuleFor(update => update.IsDone).NotEmpty();
        }
    }
}
