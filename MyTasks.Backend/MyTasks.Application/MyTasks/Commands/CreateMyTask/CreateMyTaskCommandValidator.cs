using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.CreateMyTask
{
    public class CreateMyTaskCommandValidator : AbstractValidator<CreateMyTaskCommand>
    {
        public CreateMyTaskCommandValidator()
        {
            RuleFor(createMyTaskCommand =>
                createMyTaskCommand.Type).IsInEnum().WithMessage("Type of task must be either Work or Personal");
            RuleFor(createMyTaskCommand =>
                createMyTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createMyTaskCommand =>
                createMyTaskCommand.Description).NotEmpty().MaximumLength(300).WithMessage("Please specify a description");
            RuleFor(createMyTaskCommand =>
                createMyTaskCommand.CompletedDate).Must(BeAValidDate).WithMessage("Completed date is required");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime)) && date >= DateTime.Now;
        }
    }

 
}
