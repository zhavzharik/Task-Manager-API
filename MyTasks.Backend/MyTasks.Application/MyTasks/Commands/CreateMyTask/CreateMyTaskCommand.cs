using MediatR;
using MyTasks.Domain;
using System;

namespace MyTasks.Application.MyTasks.Commands.CreateMyTask
{
    public class CreateMyTaskCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public MyTaskType Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
