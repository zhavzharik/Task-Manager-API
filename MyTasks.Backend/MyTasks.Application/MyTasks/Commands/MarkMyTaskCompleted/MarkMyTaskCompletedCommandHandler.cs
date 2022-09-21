using MediatR;
using MyTasks.Application.Common.Exceptions;
using MyTasks.Application.Interfaces;
using MyTasks.Domain;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted
{
    public class MarkMyTaskCompletedCommandHandler
         : IRequestHandler<MarkMyTaskCompletedCommand>
    {
        private readonly IMyTasksDbContext _dbContext;
        public MarkMyTaskCompletedCommandHandler(IMyTasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(MarkMyTaskCompletedCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyTasks
               .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyTask), request.Id);
            }

            entity.IsCompleted = request.IsCompleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
