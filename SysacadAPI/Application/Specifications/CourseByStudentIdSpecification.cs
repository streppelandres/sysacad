using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseByStudentIdSpecification : Specification<Domain.Entities.Course>
    {
        public CourseByStudentIdSpecification(int studentId)
        {
            Query.Where(course => course.Students.Any(sc => sc.Id == studentId));
        }
    }
}
