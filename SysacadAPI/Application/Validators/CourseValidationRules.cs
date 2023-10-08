using FluentValidation;
using System.Globalization;

namespace Application.Validators
{
    public static class CourseValidationRules
    {
        // TODO: Make this better
        private static readonly string[] Shifts = new[] { "morning", "afternoon", "night" };
        private static bool isValidShift(string input) => Shifts.Contains(input.ToLower());
        private static bool isValidQuarter(short input) => input >= 1 && input <= 4;
        private static bool isValidDateTime(string input)
            => DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _);

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
                    .WithMessage($"Incorrect quarter, valid ones: 1, 2, 3, 4");
        }

        public static IRuleBuilderOptions<T, string> ValidateDateTime<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .Must(isValidDateTime)
                    .WithMessage("{PropertyName}, invalid format. Use dd/MM/yyyy");
        }
    }
}
