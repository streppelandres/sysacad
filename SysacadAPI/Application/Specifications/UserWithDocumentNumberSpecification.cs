using Ardalis.Specification;

namespace Application.Specifications
{
    public class UserWithDocumentNumberSpecification : Specification<Domain.Entities.User>
    {
        public UserWithDocumentNumberSpecification(long documentNumber)
        {
            Query.Where(user => user.DocumentNumber == documentNumber);
        }
    }
}
