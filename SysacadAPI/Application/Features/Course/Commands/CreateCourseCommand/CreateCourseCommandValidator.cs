using Application.Constants;
using FluentValidation;
using System.Globalization;

namespace Application.Features.Course.Commands.CreateCourseCommand
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        // TODO: Make this better
        private static readonly string[] DaysOfWeek = new[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };

        private static bool ValidateDayOfWeek(string dayOfWeek) => DaysOfWeek.Contains(dayOfWeek.ToLower());

        private static bool ValidateTime(string input) 
        {
            return DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time);
        }

        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(50).WithMessage(ValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Description)
                .MaximumLength(148).WithMessage(ValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan(0).WithMessage(ValidationMessages.PropertyMustBeGreaterThanZeroMessage);

            RuleFor(x => x.MaxStudents)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan((short)0).WithMessage(ValidationMessages.PropertyMustBeGreaterThanZeroMessage);

            RuleFor(x => x.Schedules)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage);
            //.Must(schedules => schedules.Count <= DaysOfWeek.Count()).WithMessage($"Maximum of {DaysOfWeek.Count()} Schedules allowed.");

            RuleForEach(x => x.Schedules)
                .Must(schedule => ValidateDayOfWeek(schedule.DayOfWeek)).WithMessage("{PropertyName} Invalid DayOfWeek valid ones: " + string.Join(", ", DaysOfWeek))
                .Must(schedule => ValidateTime(schedule.StartTime)).WithMessage("{PropertyName}, invalid StartTime format. Use HH:mm")
                .Must(schedule => ValidateTime(schedule.EndTime)).WithMessage("{PropertyName}, invalid EndTime format. Use HH:mm");
        }
 
    }
}
