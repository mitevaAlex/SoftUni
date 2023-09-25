namespace CommandPattern.Core.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandSuffix = "Command";

        public string Read(string args)
        {
            string[] commandInfo = args.Split(' ');

            Type commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == $"{commandInfo[0]}{commandSuffix}");

            ICommand command = (ICommand)Activator.CreateInstance(commandType);

            string result = command.Execute(commandInfo[1..]);
            return result;
        }
    }
}
