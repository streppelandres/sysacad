using Application.Validators;
using FluentValidation;

namespace Application.Features.Course.Commands.DeleteCourseCommand
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(x => x.Id)
                    .NotEmpty()
                        .WithMessage(GenericValidationMessages.PropertyNameNotEmptyMessage);
        }
    }
}
