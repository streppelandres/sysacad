using Application.Validators;
using FluentValidation;

namespace Application.Features.Course.Queries.GetAllCoursesByYearAndQuarterQuery
{
    public class GetAllCoursesByYearAndQuarterValidator : AbstractValidator<GetAllCoursesByYearAndQuarterQuery>
    {
        public GetAllCoursesByYearAndQuarterValidator()
        {
            RuleFor(x => x.Quarter)
                .ValidateQuarter();
            RuleFor(x => x.Year)
                .ValidateYear();
        }
    }
}
