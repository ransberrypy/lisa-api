// using System.Threading.Tasks;
// using Microsoft.Extensions.Configuration;
// using SendGrid;
// using SendGrid.Helpers.Mail;

// public class EmailService : IEmailService
// {
//     private readonly IConfiguration _configuration;

//     public EmailService(IConfiguration configuration)
//     {
//         _configuration = configuration;
//     }

//     public async Task SendEmailAsync(string toEmail, string subject, string message)
//     {
//         var apiKey = _configuration["SendGrid:ApiKey"];
//         var client = new SendGridClient(apiKey);
//         var from = new EmailAddress("your-email@example.com", "Your Name");
//         var to = new EmailAddress(toEmail);
//         var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
//         var response = await client.SendEmailAsync(msg);
//     }
// }
