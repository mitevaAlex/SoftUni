namespace Logger.Loggers
{
    using System;
    using System.IO;
    using System.Linq;

    using Interfaces;

    public class LogFile : ILogFile
    {
        private const string filePath = "log.txt";

        public int Size => File.ReadAllText(filePath)
            .Where(x => char.IsLetter(x))
            .Sum(x => x);

        public void Write(string message)
        {
            File.AppendAllText(filePath, message + Environment.NewLine);
        }
    }
}
