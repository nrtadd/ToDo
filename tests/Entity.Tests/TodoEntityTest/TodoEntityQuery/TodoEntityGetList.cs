using Entity.Tests.TodoEntityTest.Common;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoEntities.Queries.GetListTodoEntity;

namespace Entity.Tests.TodoEntityTest.TodoEntityQuery
{
    public class TodoEntityGetList : BaseQueryTodoEntity
    {
        [Fact]
        public async Task GetListTodoEntityQuery_Success()
        {
            var query = new GetListTodoEntityQueryHandler(_context, _mapper);

            var result = await query.Handle(new GetListTodoEntityQuery()
            {
                UserId = ContextTodoEntity.UserID
            }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.list.Count == 4);

        }
        [Fact]
        public async Task GetListTodoEntityQuery_UserIDWrong_NotFoundException()
        {
            var query = new GetListTodoEntityQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetListTodoEntityQuery()
            {
                UserId = Guid.NewGuid()
            }, CancellationToken.None));

        }
    }
}
