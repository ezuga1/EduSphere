using EduSphere.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphere.Configurations
{
    public class CoursesConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(100);

            builder.Property(c => c.Level)
                .IsRequired()
                .HasDefaultValue(CourseLevels.Beginner)
                .HasConversion<string>();

            builder.Property(c => c.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("NOW()");
        }
    }
}
