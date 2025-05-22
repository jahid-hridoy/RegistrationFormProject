using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace RegistrationFormProject;

public class EmailService
{
    public async Task SendRegistrationEmailAsync(string toEmail, string userName)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Registration System Project", "your email address"));
        message.To.Add(new MailboxAddress(userName, toEmail));
        message.Subject = "Welcome to Our Platform!";

        message.Body = new TextPart("plain")
        {
            Text = $"Hello {userName},\n\nThank you for registering!"
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("your email address", "your app password");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}