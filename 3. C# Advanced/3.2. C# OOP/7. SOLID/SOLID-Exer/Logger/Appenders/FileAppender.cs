namespace Logger.Appenders
{
    using Interfaces;
    using Enumerations;

    public class FileAppender: Appender
    {
        private ILogFile file;

        public FileAppender(ILayout layout, ILogFile file) : base(layout)
        {
            this.file = file;
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            base.Append(date, reportLevel, message);
            if (string.IsNullOrEmpty(base.Content))
            {
                return;
            }

            file.Write(base.Content);
            base.Content = string.Empty;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.file.Size}";
        }
    }
}
