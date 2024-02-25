using EmailTemplatesBuilder.Models;

namespace EmailTemplatesBuilder.Data
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}