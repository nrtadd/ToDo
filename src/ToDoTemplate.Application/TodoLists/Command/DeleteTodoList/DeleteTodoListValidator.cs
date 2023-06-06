using FluentValidation;

namespace ToDoTemplate.Application.TodoLists.Command.DeleteTodoList
{
    public class DeleteTodoListValidator : AbstractValidator<DeleteTodoListCommand>
    {
        public DeleteTodoListValidator()
        {
            RuleFor(delete => delete.UserId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(delete => delete.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
