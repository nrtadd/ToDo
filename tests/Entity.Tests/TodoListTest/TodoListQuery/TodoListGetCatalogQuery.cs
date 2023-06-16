using Entity.Tests.TodoListTest.Common;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoLists.Queries.GetTodoCatalog;

namespace Entity.Tests.TodoListTest.TodoListQuery
{
    public class TodoListGetCatalogQuery : BaseQueryTodoList
    {
        [Fact]
        public async Task GetTodoCatalogQuery_Success()
        {
            var query = new GetTodoCatalogQueryHandler(_context, _mapper);

            var result = await query.Handle(new GetTodoCatalogQuery()
            {
                UserId = ContextTodoList.UserID
            }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Catalog.Count == 4);

        }
        [Fact]
        public async Task GetTodoCatalogQuery_UserIDWrong_NotFoundException()
        {
            var query = new GetTodoCatalogQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetTodoCatalogQuery()
            {
                UserId = Guid.NewGuid()
            }, CancellationToken.None));

        }
    }
}
