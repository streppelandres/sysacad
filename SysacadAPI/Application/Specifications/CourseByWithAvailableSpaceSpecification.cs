using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseByWithAvailableSpaceSpecification : Specification<Domain.Entities.Course>
    {
        public CourseByWithAvailableSpaceSpecification()
        {
            Query.Where(c =>
                c.Status.ToLower() == "new" &&
                c.MaxStudents > c.Students.Count()
            );
        }
    }
}
