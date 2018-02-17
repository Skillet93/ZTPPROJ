using EASendMail;

namespace EmailSender.Process.Common
{
    public class SmtpServerInitializer
    {
        public static SmtpServer GetSmtpServer()
        {
            var smtpServer = new SmtpServer("smtp.gmail.com")
            {
                User = "rsmreczak8dev@gmail.com",
                Password = "Zaq12wsxdev",
                ConnectType = SmtpConnectType.ConnectSSLAuto,
                Port = 465
            };
            return smtpServer;
        }
    }
}