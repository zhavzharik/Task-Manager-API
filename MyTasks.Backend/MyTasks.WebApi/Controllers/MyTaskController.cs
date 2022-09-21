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

namespace MyTasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MyTaskController : BaseController
    {
        private readonly IMapper _mapper;
        public MyTaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMyTaskDto createMyTaskDto)
        {
            var command = _mapper.Map<CreateMyTaskCommand>(createMyTaskDto);
            command.UserId = UserId;
            var myTaskId = await Mediator.Send(command);
            return Ok(myTaskId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMyTaskDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateMyTaskCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus([FromBody] MarkMyTaskCompletedDto markMyTaskCompletedDto)
        {
            var command = _mapper.Map<UpdateMyTaskCommand>(markMyTaskCompletedDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
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
