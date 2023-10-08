﻿using FluentValidation;
using System.Globalization;

namespace Application.Validators
{
    public static class ScheduleValidationRules
    {

        // TODO: Make this better
        private static readonly string[] DaysOfWeek = new[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
        private static bool ValidateDayOfWeek(string input) => DaysOfWeek.Contains(input.ToLower());

        private static bool ValidateTime(string input)
            => DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _);

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
    }
}