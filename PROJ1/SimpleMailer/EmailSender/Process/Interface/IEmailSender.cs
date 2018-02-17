using System.Collections.Generic;
using EmailSender.Process.Common;
using MailReader.Data;

namespace EmailSender.Process.Interface
{
    public interface IEmailSender
    {
        SendingResult SendEmailAsync(MailData mailData);
    }
}