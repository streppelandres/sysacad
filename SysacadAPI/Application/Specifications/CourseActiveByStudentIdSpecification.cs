using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseActiveByStudentIdSpecification : Specification<Domain.Entities.Course>
    {
        public CourseActiveByStudentIdSpecification(int studentId)
        {
            Query
                .Where(course => course.Students.Any(sc => sc.Id == studentId) &&
                      (course.Status.ToLower() == "new" || course.Status.ToLower() == "in progress"))
                .Include(course => course.Schedules);
        }
    }
}
