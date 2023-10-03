using Domain.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public bool HasToChangePassword { get; set; }
    }
}
