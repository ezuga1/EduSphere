using EduSphere.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphere.Configurations
{
    public class EventsConfiguration : IEntityTypeConfiguration<Event> 
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Date)
                .IsRequired();

            builder.Property(e => e.Location)
                .HasDefaultValue("Online")
                .HasMaxLength(100);
        }
    }
}
