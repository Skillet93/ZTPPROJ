using System.Threading.Tasks;
using EmailSender.Process.Interface;
using Logger.Log;
using MailReader.Reader.Interface;
using Quartz;
using SimpleMailer.Mailer.Interface;

namespace SimpleMailer.Mailer.MailerJob
{
    public class Mailer: IMailer
    {
        private readonly IMailReader _reader;
        private readonly IEmailSender _sender;

        public Mailer()
        {   _sender = new EmailSender.EmailSender();
            _reader = new MailReader.Reader.Loader.MailReader();
        }

        public void Execute(IJobExecutionContext context)
        {
            LoggUtil.LoggingMessage("The Email Job has been started");
            var data = _reader.Read();
            Parallel.ForEach(data,
                currentElement =>
                {
                    _sender.SendEmailAsync(currentElement);
                });
            LoggUtil.LoggingMessage("The Email Job has been ended");
        }
    }
}