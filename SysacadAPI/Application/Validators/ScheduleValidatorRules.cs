using FluentValidation;
using System.Globalization;

namespace Application.Validators
{
    public static class ScheduleValidationRules
    {

        // TODO: Make this better
        private static readonly string[] DaysOfWeek = new[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
        // TODO: Make this better
        private static readonly string[] Shifts = new[] { "morning", "afternoon", "night" };

        private static bool ValidateDayOfWeek(string input) => DaysOfWeek.Contains(input.ToLower());

        private static bool ValidateTime(string input)
            => DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _);

        private static bool ValidateShift(string input) => Shifts.Contains(input.ToLower());

        public static IRuleBuilderOptions<T, string> ValidateDayOfWeek<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(ValidateDayOfWeek)
                    .WithMessage("{PropertyName} Invalid DayOfWeek valid ones: " + string.Join(", ", DaysOfWeek));
        }

        public static IRuleBuilderOptions<T, string> ValidateTimeFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(ValidateTime)
                    .WithMessage("{PropertyName}, invalid format. Use HH:mm");
        }

        public static IRuleBuilderOptions<T, string> ValidateShift<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(ValidateShift)
                    .WithMessage("{PropertyName} Invalid Shift valid ones: " + string.Join(", ", Shifts));

        }
    }
}
