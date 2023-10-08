using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Username)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.DocumentNumber)
                .IsRequired();

            builder.HasIndex(x => x.DocumentNumber)
                .IsUnique();
        }
    }
}
