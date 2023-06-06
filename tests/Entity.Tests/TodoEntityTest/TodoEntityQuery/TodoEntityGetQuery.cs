using Entity.Tests.TodoEntityTest.Common;
using ToDoTemplate.Application.Common.Exceptions;
using ToDoTemplate.Application.TodoEntities.Queries.GetTodoEntity;

namespace Entity.Tests.TodoEntityTest.TodoEntityQuery
{
    public class TodoEntityGetQuery : BaseQueryTodoEntity
    {
        [Fact]
        public async Task GetTodoEntityQuery_Success()
        {
            var query = new GetTodoEntityQueryHandler(_context, _mapper);

            var result = await query.Handle(new GetTodoEntityQuery()
            {
                Id = ContextTodoEntity.EntitytoGet,
                UserId = ContextTodoEntity.UserID
            }, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Id == ContextTodoEntity.EntitytoGet && result.Title == "TitleEntityforGetList");

        }
        [Fact]
        public async Task GetTodoEntityQuery_EntityIDWrong_NotFoundException()
        {
            var query = new GetTodoEntityQueryHandler(_context, _mapper);
            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetTodoEntityQuery()
            {
                UserId = ContextTodoEntity.UserID,
                Id = Guid.NewGuid(),
            }, CancellationToken.None));


        }
        [Fact]
        public async Task GetTodoEntityQuery_UserIDWrong_NotFoundException()
        {
            var query = new GetTodoEntityQueryHandler(_context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(async () => await query.Handle(new GetTodoEntityQuery()
            {
                UserId = Guid.NewGuid(),
                Id = ContextTodoEntity.EntitytoGet,
            }, CancellationToken.None));

        }
    }
}
