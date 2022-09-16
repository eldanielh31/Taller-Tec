namespace API.Models;
using MailKit;
using MimeKit;
public class Mail
{
    public List<MailboxAddress> To{get;set;}
    public string Subject{get;set;}
    public string Body{get;set;}

    public Mail(IEnumerable<string> to, string subject, string content)
    {
        To = new List<MailboxAddress>();

        To.AddRange(to.Select(x => new MailboxAddress(x,x)));
        Subject = subject;
        Body = content;
    }
}