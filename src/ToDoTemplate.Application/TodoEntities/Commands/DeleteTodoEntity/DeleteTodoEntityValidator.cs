using FluentValidation;

namespace ToDoTemplate.Application.TodoEntities.Commands.DeleteTodoEntity
{
    public class DeleteTodoEntityValidator : AbstractValidator<DeleteTodoEntityCommand>
    {
        public DeleteTodoEntityValidator()
        {
            RuleFor(delete => delete.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(delete => delete.UserId).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
