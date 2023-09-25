namespace Logger.Appenders
{
    using Interfaces;
    using Enumerations;

    public abstract class Appender : IAppender
    {
        private int messagesAppended;
        protected ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
            this.ReportLevel = ReportLevelEnum.INFO;
        }

        public ReportLevelEnum ReportLevel { get; set; }

        protected string Content { get; set; }

        public virtual void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (reportLevel < this.ReportLevel)
            {
                return;
            }

            string content = string.Format(this.layout.Template, date, reportLevel, message);
            this.Content = content;
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.messagesAppended}";
        }
    }
}
