using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(s => s.ProfessorId);

            builder.HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Professor>(s => s.UserId);
        }
    }
}
