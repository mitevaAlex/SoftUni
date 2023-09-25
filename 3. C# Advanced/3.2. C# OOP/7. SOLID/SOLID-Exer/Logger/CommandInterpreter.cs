

namespace Logger
{
    using System;
    using System.Collections.Generic;

    using Appenders;
    using Interfaces;
    using Loggers;
    using Layouts;
    using Enumerations;

    public class CommandInterpreter
    {
        public IAppender[] Appenders { get; private set; }

        public List<(string reportLevel, string date, string message)> Logs { get; private set; } = new List<(string reportLevel, string date, string message)>();

        private IAppender MakeAppender(string appenderType, ILayout layout)
        {
            switch (appenderType)
            {
                case "FileAppender":
                    return new FileAppender(layout, new LogFile());
                case "ConsoleAppender":
                    return new ConsoleAppender(layout);
                default:
                    return default;
            }
        }

        private ILayout MakeLayout(string layoutType)
        {
            switch (layoutType)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    return null;
            }
        }

        private ReportLevelEnum FindReportLevel(string reportLevelString)
        {
            switch (reportLevelString)
            {
                case "INFO":
                    return ReportLevelEnum.INFO;
                case "WARNING":
                    return ReportLevelEnum.WARNING;
                case "ERROR":
                    return ReportLevelEnum.ERROR;
                case "CRITICAL":
                    return ReportLevelEnum.CRITICAL;
                case "FATAL":
                    return ReportLevelEnum.FATAL;
                default:
                    return default;
            }
        }

        public void ReadAppenders()
        {
            int appendersCount = int.Parse(Console.ReadLine());
            this.Appenders = new Appender[appendersCount];
            for (int i = 0; i < appendersCount; i++)
            {
                string[] info = Console.ReadLine().Split(' ');
                string appenderType = info[0];
                string layoutType = info[1];
                ILayout layout = MakeLayout(layoutType);
                IAppender appender = MakeAppender(appenderType, layout);
                if (info.Length == 3)
                {
                    appender.ReportLevel = FindReportLevel(info[2]);
                }

                this.Appenders[i] = appender;
            }
        }

        public void ReadMessages()
        {
            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {
                string[] info = command.Split('|');
                string reportLevel = info[0];
                string date = info[1];
                string message = info[2];
                Logs.Add((reportLevel, date, message));
            }
        }
    }
}
