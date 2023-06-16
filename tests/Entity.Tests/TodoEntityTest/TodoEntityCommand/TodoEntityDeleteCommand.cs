using Entity.Tests.TodoEntityTest.Common;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoEntities.Commands.DeleteTodoEntity;

namespace Entity.Tests.TodoEntityTest.TodoEntityCommand
{
    public class TodoEntityDeleteCommand : BaseCommandTodoEntity
    {
        [Fact]
        public async Task DeleteTodoEntityCommand_Success()
        {
            var handler = new DeleteTodoEntityHandler(_context);

            await handler.Handle(new DeleteTodoEntityCommand()
            {
                Id = ContextTodoEntity.EntitytoDelete,
                UserId = ContextTodoEntity.UserID
            }, CancellationToken.None);

            Assert.Null(_context.TodoEntities.FirstOrDefault(entity => entity.Id == ContextTodoEntity.EntitytoDelete));
        }
        [Fact]
        public async Task DeleteTodoEntityCommand_NotFoundException()
        {
            var handler = new DeleteTodoEntityHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(
                async () => await handler.Handle(new DeleteTodoEntityCommand()
                {
                    Id = Guid.NewGuid(),
                    UserId = ContextTodoEntity.UserID
                }, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteTodoEntityCommand_EntityIDWrong_NotFoundException()
        {
            var handler = new DeleteTodoEntityHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(
                async () => await handler.Handle(new DeleteTodoEntityCommand()
                {
                    Id = Guid.NewGuid(),
                    UserId = ContextTodoEntity.UserID
                }, CancellationToken.None));
        }
        [Fact]
        public async Task DeleteTodoEntityCommand_UserIDWrong_NotFoundException()
        {
            var handler = new DeleteTodoEntityHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(
                async () => await handler.Handle(new DeleteTodoEntityCommand()
                {
                    Id = ContextTodoEntity.EntitytoDelete,
                    UserId = Guid.NewGuid(),
                }, CancellationToken.None));
        }

    }
}
