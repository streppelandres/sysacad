using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(s => s.SubjectId);

            builder.Property(s => s.Code)
                .IsRequired(true);

            builder.Property(s => s.Name)
                .HasMaxLength(75)
                .IsRequired(true);

            builder.Property(s => s.Description)
                .HasMaxLength(150)
                .IsRequired(true);
        }
    }
}
