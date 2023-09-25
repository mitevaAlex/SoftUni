namespace CommandPattern.Core.Commands
{
    using Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args) => null; //Environment.Exit(0);
    }
}
