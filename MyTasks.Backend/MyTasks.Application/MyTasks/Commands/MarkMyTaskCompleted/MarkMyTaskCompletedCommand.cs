using MediatR;
using MyTasks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted
{
    public class MarkMyTaskCompletedCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public CompletedStatus IsCompleted { get; set; }
    }
}
