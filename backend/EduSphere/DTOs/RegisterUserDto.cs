using EduSphere.Models;
using System.ComponentModel.DataAnnotations;

namespace EduSphere.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.Student;
    }
}
