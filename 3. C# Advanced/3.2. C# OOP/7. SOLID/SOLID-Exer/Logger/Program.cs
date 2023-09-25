namespace Logger
{
    using System;

    using Loggers;
    using Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            commandInterpreter.ReadAppenders();
            commandInterpreter.ReadMessages();
            ILogger logger = new Logger(commandInterpreter.Appenders);
            for (int i = 0; i < commandInterpreter.Logs.Count; i++)
            {
                switch (commandInterpreter.Logs[i].reportLevel)
                {
                    case "INFO":
                        logger.Info(commandInterpreter.Logs[i].date, commandInterpreter.Logs[i].message);
                        break;
                    case "WARNING":
                        logger.Warning(commandInterpreter.Logs[i].date, commandInterpreter.Logs[i].message);
                        break;
                    case "ERROR":
                        logger.Error(commandInterpreter.Logs[i].date, commandInterpreter.Logs[i].message);
                        break;
                    case "CRITICAL":
                        logger.Critical(commandInterpreter.Logs[i].date, commandInterpreter.Logs[i].message);
                        break;
                    case "FATAL":
                        logger.Fatal(commandInterpreter.Logs[i].date, commandInterpreter.Logs[i].message);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(logger);
        }
    }
}
