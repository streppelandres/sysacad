using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.ToTable("Course");

            builder.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(p => p.Description)
                .HasMaxLength(148)
                .IsRequired(false);

            builder.Property(p => p.Code)
                .IsRequired(true);

            builder.Property(p => p.MaxStudents)
                .IsRequired(true);

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(p => p.LastModifiedBy)
                .HasMaxLength(50)
                .IsRequired(false);

            builder
                .HasMany(c => c.StudentCourses)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.HasMany(c => c.Schedules)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);
        }
    }
}
