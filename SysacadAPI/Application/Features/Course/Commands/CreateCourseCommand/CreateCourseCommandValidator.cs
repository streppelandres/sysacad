using Application.Validators;
using FluentValidation;

namespace Application.Features.Course.Commands.CreateCourseCommand
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            // TODO: Repetead in `UpdateCourseCommandValidator`
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .MaximumLength(50)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Description)
                .MaximumLength(148)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Division)
                .MaximumLength(2)
                    .WithMessage(GenericValidationMessages.PropertyNameMaxLenghtMessage);

            RuleFor(x => x.Code)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan(0)
                    .WithMessage(GenericValidationMessages.PropertyMustBeGreaterThanZeroMessage);

            RuleFor(x => x.MaxStudents)
                .NotEmpty()
                    .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage)
                .GreaterThan((short) 0)
                    .WithMessage(GenericValidationMessages.PropertyMustBeGreaterThanZeroMessage);

            RuleFor(x => x.Quarter)
                .ValidateQuarter();

            RuleFor(x => x.Shift)
                .ValidateShift();

            RuleFor(x => x.StartDate)
                .ValidateDateTime();

            RuleFor(x => x.EndDate)
                .ValidateDateTime();
        }

    }
}
