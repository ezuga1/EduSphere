using SendGrid;
using SendGrid.Helpers.Mail;
using System.Globalization;

namespace EduSphere.Services
{
    public class SendGridEmailService : IEmailService
    {

        private readonly string _apiKey;
        private readonly EmailAddress _from;
        public SendGridEmailService(IConfiguration config)
        {
            _apiKey = config["SendGrid:ApiKey"]
                ?? throw new InvalidOperationException("SengGrid API key not configured.");
            _from = new EmailAddress(
                config["SendGrid:FromEmail"] ?? throw new InvalidOperationException("SendGrid FormEmail not configured."),
                config["SendGrid:FromName"] ?? "EduSphere Support");
        }
        public async Task SendVerificationEmailAsync(string toEmail, string code)
        {
            var client = new SendGridClient(_apiKey);
            var to = new EmailAddress(toEmail);
            var subject = "EduSphere Email Verification";
            var plainText = $"Your verification code is: {code}";
            var html = $"<p>Your verification code is: </p><h2>{code}</h2>";

            var msg = MailHelper.CreateSingleEmail(_from, to , subject, plainText, html);
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);
            if(!response.IsSuccessStatusCode)
            {
                var body = await response.Body.ReadAsStringAsync();
                throw new Exception($"SendGrid send failed ({response.StatusCode}): {body}");
            }
        }
       
    }
}
