

namespace Application.Validators
{
    public static class GenericValidationMessages
    {
        public const string PropertyNameNotEmptyMessage = "{PropertyName} can't be empty";
        public const string PropertyNameMaxLenghtMessage = "{PropertyName} Cannot exceed the maximum of {MaxLength}";
        public const string PropertyNameValidEmailMessage = "{PropertyName} It must be a valid email";
        public const string PropertyMustBeGreaterThanZeroMessage = "The {PropertyName} must be greater than zero";
    }
}
