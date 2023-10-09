using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseByYearAndQuarterSpecification : Specification<Domain.Entities.Course>
    {
        public CourseByYearAndQuarterSpecification(string year, short quarter)
        {
            Query.Where(c =>
                c.Quarter == quarter &&
                (c.StartDate.Contains(year) || c.EndDate.Contains(year))
            );
        }
    }
}
