

namespace Application.Exceptions
{
    public class UserDocumentRegisteredException : ApiException
    {
        public UserDocumentRegisteredException() :base ("User document number already registered")
        {
            
        }
    }
}
