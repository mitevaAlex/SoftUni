namespace Logger.Appenders
{
    using System;

    using Interfaces;
    using Enumerations;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            base.Append(date, reportLevel, message);
            if (string.IsNullOrEmpty(base.Content))
            {
                return;
            }

            Console.WriteLine(base.Content);
            base.Content = string.Empty;
        }
    }
}
