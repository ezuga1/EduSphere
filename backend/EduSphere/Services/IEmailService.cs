using System.Runtime.CompilerServices;

namespace EduSphere.Services
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string toEmail, string code);
    }
}
