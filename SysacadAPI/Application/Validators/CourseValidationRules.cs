using FluentValidation;
using System.Globalization;

namespace Application.Validators
{
    public static class CourseValidationRules
    {
        // TODO: Make this better
        private static readonly string[] Shifts = new[] { "morning", "afternoon", "night" };

        // TODO: Make this better
        private static readonly string[] Status = new[] { "new", "in progress", "completed", "suspended" };
        private static bool isValidShift(string input) => Shifts.Contains(input.ToLower());
        private static bool isValidQuarter(short input) => input >= 1 && input <= 2;
        private static bool isValidDateTime(string input)
            => DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _);
        private static bool isValidYear(string input) => int.TryParse(input, out int _);
        private static bool isValidStatus(string input) => Status.Contains(input.ToLower());

        public static IRuleBuilderOptions<T, string> ValidateShift<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidShift)
                    .WithMessage("{PropertyName} Invalid Shift valid ones: " + string.Join(", ", Shifts));
        }

        public static IRuleBuilderOptions<T, short> ValidateQuarter<T>(this IRuleBuilder<T, short> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidQuarter)
                    .WithMessage($"Incorrect quarter, valid ones: 1, 2");
        }

        public static IRuleBuilderOptions<T, string> ValidateDateTime<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidDateTime)
                    .WithMessage("{PropertyName}, invalid format. Use dd/MM/yyyy");
        }

        public static IRuleBuilderOptions<T, string> ValidateYear<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidYear)
                    .WithMessage("{PropertyName}, invalid year");
        }

        public static IRuleBuilderOptions<T, string> ValidateStatus<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidStatus)
                    .WithMessage("{PropertyName}, invalid Status, valid ones: " + string.Join(", ", Status));
        }
    }
}
