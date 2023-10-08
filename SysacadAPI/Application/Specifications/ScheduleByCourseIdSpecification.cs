using Ardalis.Specification;


namespace Application.Specifications
{
    public class ScheduleByCourseIdSpecification : Specification<Domain.Entities.Schedule>
    {
        public ScheduleByCourseIdSpecification(int courseId)
        {
            Query.Where(schedule => schedule.CourseId == courseId);
        }
    }

}
