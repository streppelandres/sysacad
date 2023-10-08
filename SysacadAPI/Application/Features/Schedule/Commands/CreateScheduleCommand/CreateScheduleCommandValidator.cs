using Application.Validators;
using FluentValidation;

namespace Application.Features.Schedule.Commands.CreateScheduleCommand
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
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
