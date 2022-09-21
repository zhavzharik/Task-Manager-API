using FluentValidation;
using MyTasks.Application.MyTasks.Commands.UpdateMyTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Application.MyTasks.Commands.DeleteMyTask
{
    public class DeleteMyTaskCommandValidator : AbstractValidator<DeleteMyTaskCommand>
    {
        public DeleteMyTaskCommandValidator()
        {
            RuleFor(deleteMyTaskCommand =>
                deleteMyTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteMyTaskCommand =>
               deleteMyTaskCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
