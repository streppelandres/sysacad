using Application.Validators;
using FluentValidation;

namespace Application.Features.Schedule.Commands.DeleteScheduleCommand
{
    public class DeleteScheduleCommandValidator : AbstractValidator<DeleteScheduleCommand>
    {
        public DeleteScheduleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage);
        }
    }
}
