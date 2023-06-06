using Entity.Tests.TodoEntityTest.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity;

namespace Entity.Tests.TodoEntityTest.TodoEntityCommand
{
    public class TodoEntityCreateCommand : BaseCommandTodoEntity
    {
        [Fact]
        public async Task CreateTodoEntityCommand_Success()
        {
            string Description = "CreateEntity";
            string Title = "TitleCreateEntity";
            var handler = new CreateTodoEntityHandler(_context);


            var resultid = await handler.Handle(new CreateTodoEntityCommand
            {
                Description = Description,
                UserId = ContextTodoEntity.UserID,
                PiorityToDo = 0,
                Title = Title

            }, CancellationToken.None);


            Assert.NotNull(await _context.todoEntities.SingleOrDefaultAsync(
            x => x.Id == resultid 
            && x.Title == Title 
            && x.Description == Description 
            && x.UserId == ContextTodoEntity.UserID));

           
        }
    }
}
