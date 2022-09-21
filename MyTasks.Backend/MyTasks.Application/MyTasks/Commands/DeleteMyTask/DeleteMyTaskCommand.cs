using MediatR;
using System;

namespace MyTasks.Application.MyTasks.Commands.DeleteMyTask
{
    public class DeleteMyTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
