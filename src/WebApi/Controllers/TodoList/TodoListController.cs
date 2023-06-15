using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoTemplate.Application.TodoLists.Command.CreateTodoList;
using ToDoTemplate.Application.TodoLists.Command.DeleteTodoList;
using ToDoTemplate.Application.TodoLists.Command.UpdateTodoList;
using ToDoTemplate.Application.TodoLists.Queries.Common;
using ToDoTemplate.Application.TodoLists.Queries.GetTodoCatalog;
using ToDoTemplate.Application.TodoLists.Queries.GetTodoList;
using WebApi.Model.TodoList;

namespace WebApi.Controllers.TodoList
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodoListController : BaseController
    {
        private readonly IMapper _mapper;
        public TodoListController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTodoListVm>> Get(Guid id)
        {
            var query = new GetTodoListQuery
            {
                Id = id,
                UserId = UserId
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTodoCatalog>> GetAll()
        {
            var query = new GetTodoCatalogQuery
            {
                UserId = UserId
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody] CreateList createList)
        {
            var command = _mapper.Map<CreateTodoListCommand>(createList);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateList updateList)
        {
            var command = _mapper.Map<UpdateTodoListCommand>(updateList);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteTodoListCommand
            {
                UserId = UserId,
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
