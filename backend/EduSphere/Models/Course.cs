namespace EduSphere.Models
{
    public class Course
    {
        public int Id {  get; set; }
        
        public string Title { get; set; } = string.Empty;

        public string? Description {  get; set; }

        public CourseLevels Level { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public int InstructorId { get; set; }

        public User Instructor { get; set; }

    }
}
