namespace Logger.Loggers
{
    using System;
    using System.Linq;

    using Interfaces;
    using Enumerations;
    using Appenders;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string date, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, ReportLevelEnum.CRITICAL, message);
            }
        }

        public void Error(string date, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, ReportLevelEnum.ERROR, message);
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, ReportLevelEnum.FATAL, message);
            }
        }

        public void Info(string date, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, ReportLevelEnum.INFO, message);
            }
        }

        public void Warning(string date, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                appender.Append(date, ReportLevelEnum.WARNING, message);
            }
        }

        public override string ToString()
        {
            return $"Logger info{Environment.NewLine}{string.Join(Environment.NewLine, appenders.ToList().Select(x => x.ToString()))}";
        }
    }
}
