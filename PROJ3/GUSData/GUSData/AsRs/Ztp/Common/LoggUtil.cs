using System;
using System.Diagnostics;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Display;

namespace GUSData.AsRs.Ztp.Common
{
    public static class LoggUtil
    {
        private static Logger _consoleLogger;
        private static Logger _writerLogger;

        public static void LoggingTime(Stopwatch watch, ILogger log, string set)
        {
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            log.Information("Successfully {0} {Elapsed:000} ms.", set, elapsedMs);
        }

        public static Logger GetConsoleLogger()
        {
            return _consoleLogger ?? (_consoleLogger = new LoggerConfiguration()
                       .WriteTo.Console()
                       .CreateLogger());
        }

        public static Logger GetWriterLogger()
        {
            return _writerLogger ?? (_writerLogger = new LoggerConfiguration()
                       .WriteTo.RollingFile(new MessageTemplateTextFormatter(Constants.FileConstant.FileFormat, null),
                           PrepareFileName())
                       .CreateLogger());
        }

        private static string PrepareFileName()
        {
            var random = new Random();
            var fileId = random.Next(0, Constants.FileConstant.MaxFileNameIdNumberFormat).ToString()
                .PadLeft(Constants.FileConstant.MaxFileNameIdNumberFormat.ToString().Length, '0');
            var currentFileName = fileId + Constants.FileConstant.FileNameFormat;
            return currentFileName;
        }
    }
}