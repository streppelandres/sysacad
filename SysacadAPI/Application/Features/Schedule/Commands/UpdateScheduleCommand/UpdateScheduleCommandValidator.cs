using Application.Validators;
using FluentValidation;

namespace Application.Features.Schedule.Commands.UpdateScheduleCommand
{
    public class UpdateScheduleCommandValidator : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage);
            
            RuleFor(x => x.DayOfWeek)
                .ValidateDayOfWeek();
            
            RuleFor(x => x.StartTime)
                .ValidateTimeFormat();
            
            RuleFor(x => x.EndTime)
                .ValidateTimeFormat();

            RuleFor(x => x.Shift)
                .ValidateShift();
        }
    }
}
