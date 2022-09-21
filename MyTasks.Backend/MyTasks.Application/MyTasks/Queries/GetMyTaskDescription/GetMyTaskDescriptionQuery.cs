using MediatR;
using System;


namespace MyTasks.Application.MyTasks.Queries.GetMyTaskDescription
{
    public class GetMyTaskDescriptionQuery : IRequest<MyTaskDescriptionVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
