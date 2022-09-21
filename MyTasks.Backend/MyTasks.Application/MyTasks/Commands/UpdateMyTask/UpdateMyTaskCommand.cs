using MediatR;
using MyTasks.Domain;
using System;

namespace MyTasks.Application.MyTasks.Commands.UpdateMyTask
{
    public class UpdateMyTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public MyTaskType Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
