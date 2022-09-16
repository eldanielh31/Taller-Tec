namespace API.Email;
using API.Models;
using MailKit;
using MimeKit;

public class EmailSender : IEmailSender
{
    private readonly MailSettings _emailConfig;

    public EmailSender(MailSettings emailConfig)
    {
        _emailConfig = emailConfig;
    }

    public void SendEmail(Mail message)
    {
        var emailMessage = CreateEmailMessage(message);
        Send(emailMessage);
    }
    private MimeMessage CreateEmailMessage(Mail message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("email",_emailConfig.Mail));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            try
            {
                client.Connect(_emailConfig.Host, _emailConfig.Port,false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                //client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}