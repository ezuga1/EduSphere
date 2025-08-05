using EduSphere.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduSphere.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u =>u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasDefaultValue(UserRole.Student)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasMany(u => u.Courses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.Instructor.Id);

            builder.HasMany(u => u.Events)
                .WithOne(e => e.Organizer)
                .HasForeignKey(e => e.OrganizerId);
        }

    }
}
