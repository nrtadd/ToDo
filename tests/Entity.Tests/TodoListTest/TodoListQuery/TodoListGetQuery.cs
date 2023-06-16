using Entity.Tests.TodoListTest.Common;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoLists.Queries.GetTodoList;

namespace Entity.Tests.TodoListTest.TodoListQuery
{
    public class TodolistGetQuery : BaseQueryTodoList
    {

        [Fact]
        public async Task GetTodoListQuery_Success()
        {
            var query = new GetTodoListQueryHandler(_context, _mapper);

            var result = await query.Handle(new GetTodoListQuery()
            {
                Id = ContextTodoList.ListEntitytoGet,
                UserId = ContextTodoList.UserID
            }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Id == ContextTodoList.ListEntitytoGet && result.Title == "ListForGet");

        }
        [Fact]
        public async Task GetTodoListQuery_UserIDWrong_NotFoundException()
        {
            var query = new GetTodoListQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetTodoListQuery()
            {
                Id = ContextTodoList.ListEntitytoGet,
                UserId = Guid.NewGuid()
            }, CancellationToken.None));

        }
        [Fact]
        public async Task GetTodoListQuery_EntityIDWrong_NotFoundException()
        {
            var query = new GetTodoListQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetTodoListQuery()
            {
                Id = Guid.NewGuid(),
                UserId = ContextTodoList.UserID
            }, CancellationToken.None));

        }
    }
}
