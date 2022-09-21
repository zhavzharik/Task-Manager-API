using FluentValidation;
using System;

namespace MyTasks.Application.MyTasks.Commands.UpdateMyTask
{
    public class UpdateMyTaskCommandValidator : AbstractValidator<UpdateMyTaskCommand>
    {
        public UpdateMyTaskCommandValidator()
        {
            RuleFor(updateMyTaskCommand =>
                updateMyTaskCommand.Type).IsInEnum().WithMessage("Type of task must be either Work or Personal");
            RuleFor(updateMyTaskCommand =>
                updateMyTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateMyTaskCommand =>
               updateMyTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateMyTaskCommand =>
                updateMyTaskCommand.Description).MaximumLength(300);
            RuleFor(updateMyTaskCommand =>
                updateMyTaskCommand.CompletedDate).Must(BeAValidDate).WithMessage("Completed date is required");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
