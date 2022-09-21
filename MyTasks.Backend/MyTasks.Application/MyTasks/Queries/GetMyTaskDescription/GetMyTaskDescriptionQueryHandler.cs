using AutoMapper;
using MediatR;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Common.Exceptions;
using MyTasks.Domain;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyTasks.Application.MyTasks.Queries.GetMyTaskDescription
{
    public class GetMyTaskDescriptionQueryHandler
         : IRequestHandler<GetMyTaskDescriptionQuery, MyTaskDescriptionVm>
    {
        private readonly IMyTasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMyTaskDescriptionQueryHandler(IMyTasksDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MyTaskDescriptionVm> Handle(GetMyTaskDescriptionQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyTasks
                .FirstOrDefaultAsync(mytask =>
                mytask.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(MyTask), request.Id);
            }

            return _mapper.Map<MyTaskDescriptionVm>(entity);
        }
    }
}
