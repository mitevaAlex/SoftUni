namespace CommandPattern
{
    using Core.Models;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
