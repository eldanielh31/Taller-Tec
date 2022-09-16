namespace API.Email;
using API.Models;

public interface IEmailSender
{
    void SendEmail(Mail message);
}