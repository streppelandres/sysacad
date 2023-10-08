using Ardalis.Specification;

namespace Application.Specifications
{
    public class UserWithIdSpecification : Specification<Domain.Entities.User>
    {
        public UserWithIdSpecification(int userId)
        {
            Query.Where(u => u.Id == userId);    
        }
    }
}
