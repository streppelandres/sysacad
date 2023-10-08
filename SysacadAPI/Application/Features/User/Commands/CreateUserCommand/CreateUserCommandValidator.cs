using Application.Validators;
using FluentValidation;

namespace Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(80).WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(256).WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .EmailAddress().WithMessage(GenericValidationMessages.PropertyNameValidEmailMessage);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage);
        }
    }
}
