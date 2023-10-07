using Ardalis.Specification;

namespace Application.Specifications
{
    public class CourseWithCodeSpecification : Specification<Domain.Entities.Course>
    {
        public CourseWithCodeSpecification(int code)
        {
            Query.Where(course => course.Code == code);
        }
    }
}
