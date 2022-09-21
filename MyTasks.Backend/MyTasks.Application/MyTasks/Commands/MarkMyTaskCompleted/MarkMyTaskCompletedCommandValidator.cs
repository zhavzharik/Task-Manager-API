using FluentValidation;
using MyTasks.Application.MyTasks.Commands.CreateMyTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Application.MyTasks.Commands.MarkMyTaskCompleted
{
    public class MarkMyTaskCompletedCommandValidator : AbstractValidator<MarkMyTaskCompletedCommand>
    {
        public MarkMyTaskCompletedCommandValidator()
        {
            RuleFor(markMyTaskCompletedCommand =>
                markMyTaskCompletedCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(markMyTaskCompletedCommand =>
               markMyTaskCompletedCommand.Id).NotEqual(Guid.Empty);
            RuleFor(markMyTaskCompletedCommand =>
                markMyTaskCompletedCommand.IsCompleted).IsInEnum().WithMessage("Status of task must be either NotCompleted or Done"); 
        }
    }
}
