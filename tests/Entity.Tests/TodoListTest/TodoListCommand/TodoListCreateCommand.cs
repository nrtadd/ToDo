using Entity.Tests.TodoListTest.Common;
using Microsoft.EntityFrameworkCore;
using ToDoTemplate.Application.TodoLists.Command.CreateTodoList;

namespace Entity.Tests.TodoListTest.TodoListCommand
{
    public class TodoListCreateCommand : BaseCommandTodoList
    {
        [Fact]
        public async Task CreateTodoListCommand_Success()
        {
            var handler = new CreateTodoListHandler(_context);

            var listid =await handler.Handle(new CreateTodoListCommand()
            {
                Title = "CreateTodoList",
                UserId = ContextTodoList.UserID
            }, CancellationToken.None);

            Assert.NotNull(await _context.todoLists.FirstOrDefaultAsync(entity => entity.Id == listid
            && entity.UserId == ContextTodoList.UserID));

        }
    }
}
