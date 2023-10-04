using FluentValidation;

namespace Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        // TODO: Move these:
        public const string PropertyNameNotEmptyMessage = "{PropertyName} can't be empty";
        public const string PropertyNameMaxLenghtMessage = "{PropertyName} Cannot exceed the maximum of {MaxLength}";
        public const string PropertyNameValidEmailMessage = "{PropertyName} It must be a valid email";

        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(PropertyNameNotEmptyMessage)
                .MaximumLength(80).WithMessage(PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(PropertyNameNotEmptyMessage)
                .MaximumLength(256).WithMessage(PropertyNameMaxLenghtMessage); ;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(PropertyNameNotEmptyMessage)
                .EmailAddress().WithMessage(PropertyNameValidEmailMessage);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(PropertyNameNotEmptyMessage);
        }
    }
}
