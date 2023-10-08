using Ardalis.Specification;

namespace Application.Specifications
{
    public class StudentRegisteredUserSpecification : Specification<Domain.Entities.Student>
    {
        public StudentRegisteredUserSpecification(int userId)
        {
            Query.Where(s => s.UserId == userId);
        }
    }
}
