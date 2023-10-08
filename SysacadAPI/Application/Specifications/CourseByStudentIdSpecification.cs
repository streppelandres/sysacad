using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseByStudentIdSpecification : Specification<Domain.Entities.Course>
    {
        public CourseByStudentIdSpecification(int studentId)
        {
            Query.Where(course => course.StudentCourses.Any(sc => sc.StudentId == studentId));
        }
    }
}
