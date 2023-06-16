using Entity.Tests.TodoListTest.Common;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoLists.Command.UpdateTodoList;

namespace Entity.Tests.TodoListTest.TodoListCommand
{
    public class TodoListUpdateCommand : BaseCommandTodoList
    {
        readonly string title = "ListForUpdateSuccess";
        [Fact]
        public async Task UpdateTodoListCommand_Success()
        {
            var handler = new UpdateTodoListHandler(_context);

            await handler.Handle(new UpdateTodoListCommand()
            {
                Id = ContextTodoList.ListEntitytoUpdate,
                Title = title,
                UserId = ContextTodoList.UserID,
                Todos = null
            }, CancellationToken.None);

            Assert.NotNull(await _context.TodoLists.FirstOrDefaultAsync(entity => entity.Id == ContextTodoList.ListEntitytoUpdate
            && entity.Title == title
            && entity.UserId == ContextTodoList.UserID));
        }
        [Fact]
        public async Task UpdateTodoListCommand_UserIDWrong_NotFoundException()
        {
            var handler = new UpdateTodoListHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateTodoListCommand()
            {
                Id = Guid.NewGuid(),
                UserId = ContextTodoList.UserID,
                Title = title,
                Todos = null
            }, CancellationToken.None));

        }
        [Fact]
        public async Task UpdateTodoListCommand_EntityIDWrong_NotFoundException()
        {
            var handler = new UpdateTodoListHandler(_context);

            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateTodoListCommand()
            {
                Id = ContextTodoList.ListEntitytoUpdate,
                UserId = Guid.NewGuid(),
                Title = title,
                Todos = null
            }, CancellationToken.None));
        }

    }
}
