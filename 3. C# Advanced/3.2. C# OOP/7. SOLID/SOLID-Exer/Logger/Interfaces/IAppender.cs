namespace Logger.Interfaces
{
    using Enumerations;

    public interface IAppender
    {
        ReportLevelEnum ReportLevel { get; set; }

        void Append(string date, ReportLevelEnum reportLevel, string message);
    }
}
