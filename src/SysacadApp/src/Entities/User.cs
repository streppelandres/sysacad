

namespace Entities
{
    public enum Rol
    {
        Administrator, Student, Profesor
    }

    public class User
    {
        public virtual int UserId { get; set; }
        public Rol Rol { get; set; }
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
