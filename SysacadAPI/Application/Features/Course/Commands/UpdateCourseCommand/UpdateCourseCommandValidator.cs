using Application.Validators;
using FluentValidation;

namespace Application.Features.Course.Commands.UpdateCourseCommand
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            // TODO: Repetead in `CreateCourseCommandValidator`
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(50)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Description)
                .MaximumLength(148)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Division)
                .MaximumLength(1)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Code)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan(0)
                    .WithMessage(GenericValidationMessages.PropertyMustBeGreaterThanZeroMessage);

            RuleFor(x => x.MaxStudents)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan((short)0)
                    .WithMessage(GenericValidationMessages.PropertyMustBeGreaterThanZeroMessage);
        }
    }
}
