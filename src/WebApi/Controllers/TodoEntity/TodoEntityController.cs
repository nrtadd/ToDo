using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoTemplate.Application.TodoEntities.Commands.CreateTodoEntity;
using ToDoTemplate.Application.TodoEntities.Commands.DeleteTodoEntity;
using ToDoTemplate.Application.TodoEntities.Commands.UpdateTodoEntity;
using ToDoTemplate.Application.TodoEntities.Queries.Common;
using ToDoTemplate.Application.TodoEntities.Queries.GetListTodoEntity;
using ToDoTemplate.Application.TodoEntities.Queries.GetTodoEntity;
using WebApi.Model.TodoEntity;

namespace WebApi.Controllers.TodoEntity
{
    [Authorize]
    [Route("api/[controller]")]
    public class TodoEntityController : BaseController
    {
        private readonly IMapper _mapper;

        public TodoEntityController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetTodoEntityVm>> Get(Guid id)
        {
            var query = new GetTodoEntityQuery
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
        public async Task<ActionResult<GetListTodoEntityList>> GetAll()
        {
            var query = new GetListTodoEntityQuery
            {
                UserId = UserId
            };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoEntity createTodoEntity)
        {
            var command = _mapper.Map<CreateTodoEntityCommand>(createTodoEntity);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateTodoEntity updateTodoEntity)
        {
            var command = _mapper.Map<UpdateTodoEntityCommand>(updateTodoEntity);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteTodoEntityCommand
            {
                UserId = UserId,
                Id = id,
            };
            var result = await Mediator.Send(command);
            return NoContent();
        }

    }
}
