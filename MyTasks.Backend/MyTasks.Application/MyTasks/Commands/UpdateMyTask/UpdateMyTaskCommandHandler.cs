using MediatR;
using MyTasks.Application.Interfaces;
using MyTasks.Domain;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Common.Exceptions;


namespace MyTasks.Application.MyTasks.Commands.UpdateMyTask
{
    public class UpdateMyTaskCommandHandler
        : IRequestHandler<UpdateMyTaskCommand>
    {
        private readonly IMyTasksDbContext _dbContext;
        public UpdateMyTaskCommandHandler(IMyTasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateMyTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.MyTasks.FirstOrDefaultAsync(mytask =>
                    mytask.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyTask), request.Id);
            }

            entity.Type = request.Type;
            entity.Description = request.Description;
            entity.CompletedDate = request.CompletedDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
