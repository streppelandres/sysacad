using Application.Constants;
using FluentValidation;

namespace Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(80).WithMessage(ValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(256).WithMessage(ValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage)
                .EmailAddress().WithMessage(ValidationMessages.PropertyNameValidEmailMessage);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(ValidationMessages.PropertyNameNotEmptyMessage);
        }
    }
}
