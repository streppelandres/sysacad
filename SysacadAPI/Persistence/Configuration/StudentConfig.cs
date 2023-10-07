using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder
                .HasMany(e => e.StudentCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);
        }
    }
}
