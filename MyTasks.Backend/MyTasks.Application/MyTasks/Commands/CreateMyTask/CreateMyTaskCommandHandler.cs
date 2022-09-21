using MediatR;
using MyTasks.Application.Interfaces;
using MyTasks.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyTasks.Application.MyTasks.Commands.CreateMyTask
{
    public class CreateMyTaskCommandHandler
        :IRequestHandler<CreateMyTaskCommand, Guid>
    {
        private readonly IMyTasksDbContext _dbContext;
        public CreateMyTaskCommandHandler(IMyTasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateMyTaskCommand request,
            CancellationToken cancellationToken)
        {
            var mytask = new MyTask
            {
                UserId = request.UserId,
                Type = request.Type,
                Description = request.Description,
                Id = Guid.NewGuid(),
                CompletedDate = request.CompletedDate,
                IsCompleted = CompletedStatus.NotComleted
            };

            await _dbContext.MyTasks.AddAsync(mytask, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return mytask.Id;
        }   
    }
}
