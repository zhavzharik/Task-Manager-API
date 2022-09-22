using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTasks.Application.MyTasks.Queries.GetMyTaskDescription;
using MyTasks.Application.MyTasks.Commands.CreateMyTask;
using MyTasks.Application.MyTasks.Commands.DeleteMyTask;
using MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted;
using MyTasks.Application.MyTasks.Commands.UpdateMyTask;
using System;
using System.Threading.Tasks;
using MyTasks.WebApi.Models;
using Microsoft.AspNetCore.Http;

namespace MyTasks.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MyTaskController : BaseController
    {
        private readonly IMapper _mapper;
        public MyTaskController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the task by id
        /// </summary>
        /// <remarks>
        /// Sample request
        /// GET /mytask/{416F30A4-FCD8-42D6-9AD1-AC09FB2B3CCC}
        /// </remarks>
        /// <param name="id">My Task id (guid)</param>
        /// <returns>Returns MyTaskDescriptionVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MyTaskDescriptionVm>> Get(Guid id)
        {
            var query = new GetMyTaskDescriptionQuery()
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /mytask
        /// {
        ///     type: "neither Work or Personal",
        ///     description: "task description",
        ///     completedDate: "task completion date"
        /// }
        /// </remarks>
        /// <param name="createMyTaskDto">CreateMyTaskDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMyTaskDto createMyTaskDto)
        {
            var command = _mapper.Map<CreateMyTaskCommand>(createMyTaskDto);
            command.UserId = UserId;
            var myTaskId = await Mediator.Send(command);
            return Ok(myTaskId);
        }

        /// <summary>
        /// Update the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /mytask
        /// {
        ///     type: "neither Work or Personal",
        ///     description: "update task description",
        ///     completedDate: "update task completion date"
        /// }
        /// </remarks>
        /// <param name="updateMyTaskDto">UpdateMyTaskDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateMyTaskDto updateMyTaskDto)
        {
            var command = _mapper.Map<UpdateMyTaskCommand>(updateMyTaskDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Update the status of task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /mytask/{9F85B274-EBC9-4FA8-BA3A-C7AC360C56E4}
        /// {
        ///     isCompleted: "neither NotCompleted or Done"
        /// }
        /// </remarks>
        /// <param name="markMyTaskCompletedDto, id">markMyTaskCompletedDto object by id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateStatus([FromBody] MarkMyTaskCompletedDto markMyTaskCompletedDto, Guid id)
        {
            var command = _mapper.Map<MarkMyTaskCompletedCommand>(markMyTaskCompletedDto);
            command.UserId = UserId;
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /mytask/{2A8BA626-B91A-41F1-8079-05A1AC974105}
        /// </remarks>
        /// <param name="id">Id of the task (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMyTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
