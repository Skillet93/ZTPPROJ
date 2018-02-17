using Logger.Log;
using SimpleMailer.Mailer.Interface;

namespace SimpleMailer.Mailer.MailerService
{
    public class MailerService : IMailerService
    {
        public void Start()
        {
            LoggUtil.LoggingMessage("Mailer service start!");
        }

        public void Stop()
        {
            LoggUtil.LoggingMessage("Mailer service stop!");
        }
    }
}