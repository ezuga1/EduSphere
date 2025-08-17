using EduSphere.Configurations;
using EduSphere.Models;
using Microsoft.EntityFrameworkCore;

namespace EduSphere.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { 

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
            modelBuilder.ApplyConfiguration(new EventsConfiguration());
            modelBuilder.ApplyConfiguration(new  UsersConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}
