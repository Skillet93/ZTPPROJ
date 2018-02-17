using Quartz;
using SimpleMailer.Mailer.Interface;
using SimpleMailer.Mailer.MailerService;
using Topshelf;
using Topshelf.Quartz;


namespace SimpleMailer
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.SetServiceName("SimpleMailer");
                x.SetDisplayName("SimpleMailer");
                x.SetDescription("This is a email service");

                x.Service<IMailerService>(service =>
                {
                    service.ConstructUsing(srv => new MailerService());

                    service.WhenStarted(srv => srv.Start());
                    service.WhenStopped(srv => srv.Stop());
                    service.ScheduleQuartzJob(q =>
                        q.WithJob(() =>
                                JobBuilder.Create<Mailer.MailerJob.Mailer>().Build())
                            .AddTrigger(() => TriggerBuilder.Create()
                                .WithSimpleSchedule(b => b
                                    .WithIntervalInSeconds(60)
                                    .RepeatForever())
                                .Build()));
                });
                
                x.RunAsLocalSystem()
                    .DependsOnEventLog()
                    .StartAutomatically()
                    .EnableServiceRecovery(rc => rc.RestartService(1));
            });
        }
    }
}