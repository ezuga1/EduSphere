using SendGrid;
using SendGrid.Helpers.Mail;
using System.Globalization;

namespace EduSphere.Services
{
    public class SendGridEmailService : IEmailService
    {

        private readonly SendGridClient _client;
        private readonly EmailAddress _from;
        public SendGridEmailService(IConfiguration config, SendGridClient client)
        {
            _client = client ?? throw new InvalidOperationException("SendGridClient not configured");
            _from = new EmailAddress(
                config["SendGrid:FromEmail"] ?? throw new InvalidOperationException("SendGrid FromEmail not configured."),
                config["SendGrid:FromName"] ?? "EduSphere Support");
        }
        public async Task SendVerificationEmailAsync(string toEmail, string code)
        {
            var to = new EmailAddress(toEmail);
            var subject = "EduSphere Email Verification";
            var plainText = $"Your verification code is: {code}";
            var html = $"<p>Your verification code is: </p><h2>{code}</h2>";

            var msg = MailHelper.CreateSingleEmail(_from, to , subject, plainText, html);
            msg.SetClickTracking(false, false);

            var response = await _client.SendEmailAsync(msg);
            if(!response.IsSuccessStatusCode)
            {
                var body = await response.Body.ReadAsStringAsync();
                throw new Exception($"SendGrid send failed ({response.StatusCode}): {body}");
            }
        }
       
    }
}
