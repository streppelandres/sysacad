

namespace Application.Exceptions
{
    public class CourseCodeRegisteredException : ApiException
    {
        public CourseCodeRegisteredException() : base("Course code already registered")
        {
            
        }
    }
}
