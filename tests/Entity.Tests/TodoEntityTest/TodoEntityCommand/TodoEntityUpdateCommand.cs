using Entity.Tests.TodoEntityTest.Common;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity;
using ToDoTemplate.Domain.Enums;

namespace Entity.Tests.TodoEntityTest.TodoEntityCommand
{
    public class TodoEntityUpdateCommand : BaseCommandTodoEntity
    {
        readonly string title = "TitleEntityforUpdateSuccess";
        readonly string description = "DescriptionEntityforUpdate";
        [Fact]
        public async Task UpdateTodoEntityCommand_Success()
        {

            var handler = new UpdateTodoEntityHandler(_context);

            await handler.Handle(new UpdateTodoEntityCommand()
            {
                Description = description,
                Title = title,
                Id = ContextTodoEntity.EntitytoUpdate,
                UserId = ContextTodoEntity.UserID,
                IsDone = true,
                PriorityToDo = Priority.Critical,
            }, CancellationToken.None);

            Assert.NotNull(await _context.todoEntities.FirstOrDefaultAsync(entity => entity.Id == ContextTodoEntity.EntitytoUpdate
            && entity.Title == title
            && entity.Description == description
            && entity.UserId == ContextTodoEntity.UserID));
        }
        [Fact]
        public async Task UpdateTodoEntityCommand_EntityIDWrong_NotFoundException()
        {
            var handler = new UpdateTodoEntityHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateTodoEntityCommand()
            {
                Description = description,
                Title = title,
                Id = Guid.NewGuid(),
                UserId = ContextTodoEntity.UserID,
                IsDone = true,
                PriorityToDo = Priority.Critical,
            }, CancellationToken.None));
        }
        [Fact]
        public async Task UpdateTodoEntityCommand_UserIDWrong_NotFoundException()
        {
            var handler = new UpdateTodoEntityHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateTodoEntityCommand()
            {
                Description = description,
                Title = title,
                Id = ContextTodoEntity.EntitytoUpdate,
                UserId = Guid.NewGuid(),
                IsDone = true,
                PriorityToDo = Priority.Critical,
            }, CancellationToken.None));
        }
    }
}
