using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(s => s.ScheduleId);

            builder.Property(c => c.Day)
                .HasConversion<int>()
                .IsRequired(true);

            builder.Property(c => c.StartTime)
                .HasColumnType("date")
                .IsRequired(true);

            builder.Property(c => c.EndTime)
                .HasColumnType("date")
                .IsRequired(true);
        }
    }
}
