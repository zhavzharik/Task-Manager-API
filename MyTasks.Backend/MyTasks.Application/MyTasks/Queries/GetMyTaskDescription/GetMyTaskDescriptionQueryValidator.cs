using FluentValidation;
using System;

namespace MyTasks.Application.MyTasks.Queries.GetMyTaskDescription
{
    public class GetMyTaskDescriptionQueryValidator : AbstractValidator<GetMyTaskDescriptionQuery>
    {
        public GetMyTaskDescriptionQueryValidator()
        {
            RuleFor(mytask => mytask.UserId).NotEqual(Guid.Empty);
            RuleFor(mytask => mytask.Id).NotEqual(Guid.Empty);
        }
    }
}
