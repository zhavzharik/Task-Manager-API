using MediatR;
using MyTasks.Domain;
using System;

namespace MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted
{
    public class MarkMyTaskCompletedCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public CompletedStatus IsCompleted { get; set; }
    }
}
