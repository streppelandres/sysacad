using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseByYearAndQuarterpecification : Specification<Domain.Entities.Course>
    {
        public CourseByYearAndQuarterpecification(string year, short quarter)
        {
            Query.Where(c =>
                c.Quarter == quarter &&
                (c.StartDate.Contains(year) || c.EndDate.Contains(year))
            );
        }
    }
}
