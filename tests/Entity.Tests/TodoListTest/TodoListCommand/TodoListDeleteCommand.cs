using Entity.Tests.TodoListTest.Common;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoLists.Command.DeleteTodoList;

namespace Entity.Tests.TodoListTest.TodoListCommand
{
    public class TodoListDeleteCommand : BaseCommandTodoList
    {
        [Fact]
        public async Task DeleteTodoListCommand_Success()
        {
            var handler = new DeleteTodoListHandler(_context);
            await handler.Handle(new DeleteTodoListCommand()
            {
                Id = ContextTodoList.ListEntitytoDelete,
                UserId = ContextTodoList.UserID
            }, CancellationToken.None);
            Assert.Null(await _context.TodoLists.FirstOrDefaultAsync(entity => entity.Id == ContextTodoList.ListEntitytoDelete && entity.UserId == ContextTodoList.UserID));
        }
        [Fact]
        public async Task DeleteTodoListCommand_UserIDWrong_NotFoundException()
        {
            var handler = new DeleteTodoListHandler(_context);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTodoListCommand()
            {
                UserId = Guid.NewGuid(),
                Id = ContextTodoList.ListEntitytoDelete
            }, CancellationToken.None));

        }
        public async Task DeleteTodoListCommand_EntityIDWrong_NotFoundException()
        {
            var handler = new DeleteTodoListHandler(_context);
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new DeleteTodoListCommand()
            {
                UserId = ContextTodoList.UserID,
                Id = Guid.NewGuid()
            }, CancellationToken.None));

        }
    }
}
