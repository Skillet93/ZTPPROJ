using System;
using EmailSender.Process.Common;
using EmailSender.Process.Interface;
using Logger.Log;
using MailReader.Data;

namespace EmailSender
{
    public class EmailSender : IEmailSender
    {
        public SendingResult SendEmailAsync(MailData mailData)
        {
            try
            {
                LoggUtil.LoggEmailData(mailData);
                LoggUtil.LoggingMessage("The email {Email} has been sent successfully", mailData.Address);
            }
            catch (Exception ep)
            {
                LoggUtil.LoggingError($"Failed to send email to {mailData}: ", ep.Message);
                return SendingResult.Fail;
            }
            return SendingResult.Success;
        }
    }
}