using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using RapidERP.Application.Interfaces;

namespace RapidERP.Infrastructure.Services;

public class CommunicationService : ICommunication
{
    public string SendEmail(string to, string subject, string body, string parameter)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("FromNameTest", "rapid11141@gmail.com"));
        message.To.Add(new MailboxAddress("", to));
        message.Subject = "Rapid Notification";
        message.Body = new TextPart("html") { Text = parameter.ToString() };

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            client.Authenticate("rapid11141@gmail.com", "jhhq xmig wovp hkij");
            client.Send(message);
            client.Disconnect(true);
        }

        return "Email Sent Successfully";
    }
}
