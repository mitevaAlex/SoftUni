namespace CommandPattern.Core.Models
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string result = this.commandInterpreter.Read(Console.ReadLine());
                if (result == null)
                {
                    break;
                }

                Console.WriteLine(result);
            }
        }
    }
}
