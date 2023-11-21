using Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration.Relationships
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment");

            builder.HasKey(e => e.EnrollmentId);
            builder.HasIndex(e => new { e.CourseId, e.StudentId });

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
