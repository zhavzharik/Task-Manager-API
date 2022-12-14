using MediatR;
using MyTasks.Application.Common.Exceptions;
using MyTasks.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTasks.Application.MyTasks.Commands.DeleteMyTask
{
    public class DeleteMyTaskCommandHandler
        : IRequestHandler<DeleteMyTaskCommand>
    {
        private readonly IMyTasksDbContext _dbContext;
        public DeleteMyTaskCommandHandler(IMyTasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteMyTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyTasks
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyTasks), request.Id);
            }

            _dbContext.MyTasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
