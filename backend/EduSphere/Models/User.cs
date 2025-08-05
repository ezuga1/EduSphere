namespace EduSphere.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public UserRole Role { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
