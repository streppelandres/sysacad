using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");
            builder.HasKey(c => c.CourseId);

            builder.HasOne(c => c.Professor)
                .WithMany(p => p.Courses)
                .HasForeignKey(c => c.ProfessorId);

            builder.HasOne(c => c.Subject)
                .WithMany()
                .HasForeignKey(c => c.SubjectId);

            builder.HasMany(c => c.Schedules)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Status)
                .HasDefaultValue(CourseStatus.New)
                .HasConversion<int>()
                .IsRequired(true);

            builder.Property(c => c.Division)
                .HasMaxLength(5)
                .IsRequired(true);

            builder.Property(c => c.StartDate)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(c => c.EndDate)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(c => c.Quarter)
                .HasConversion<int>()
                .IsRequired(true);

            builder.Property(c => c.Shift)
                .HasConversion<int>()
                .IsRequired(true);

            builder.Property(c => c.Room)
                .HasMaxLength(15)
                .IsRequired(true);

            builder.Property(c => c.Code)
                .IsRequired(true);

            builder.HasIndex(c => c.Code)
                .IsUnique(true);
        }
    }
}
