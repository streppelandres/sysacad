using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(s => s.StudentId);

            builder.HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId);
        }
    }
}
