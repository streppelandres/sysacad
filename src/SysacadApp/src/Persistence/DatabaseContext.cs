using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DatabaseContext() : base() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // FIXME: Retrive from App.config
            string connectionString = "Data Source=DESKTOP-SU4TO1T\\SQLEXPRESS01;Initial Catalog=sysacad;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
